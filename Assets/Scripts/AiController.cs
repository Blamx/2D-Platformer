using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Vector2 playerPosition;
    [SerializeField]
    Transform enemyPosition;
    Rigidbody2D rb;
    Enemy enemy;
    Collider2D detectionRange;
    [SerializeField]
    Animator animator;
    float animationSpeed;

    [SerializeField]
    float rotationSpeed = 2.0f;

    [SerializeField]
    float MeleeRange = 2.0f;

    [SerializeField]
    float KitingRange = 15.0f;

    [SerializeField]
    bool canFly = false;



    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        enemy = GetComponentInParent<Enemy>();
        rb = enemy.GetComponent<Rigidbody2D>();
        detectionRange = GetComponent<Collider2D>();
        animationSpeed = 0;
    }
    private void FixedUpdate()
    {
        playerPosition = player.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if other collision has player tag
        if (collision.gameObject.tag == "Player")
        {
            //check archetype
            switch (enemy.type)
            {
                case Enemy.Archetype.Melee:
                    MeleeAttackPattern();
                    break;
                case Enemy.Archetype.Ranged:
                    RangedAttackPattern();
                    break;
            }

        }
        //take action based on archetype
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyAttack")
            return;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetFloat("Speed", 0);
    }

    private void RangedAttackPattern()
    {
        Vector2 enemyPosition = transform.position;
        Vector2 direction = playerPosition - enemyPosition;
        float magnitude = direction.magnitude;
        //Debug.Log(magnitude);

        if(magnitude >= KitingRange)
        {
            rb.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
            TurnToEnemy();
            enemy.Attack();
        }
        else
            MoveAwayFromPlayer();
    }

    private void MeleeAttackPattern()
    {
        Vector2 enemyPosition = transform.position;
        Vector2 direction = playerPosition - enemyPosition;
        float magnitude = direction.magnitude;

        //if player is in range attack
        //Debug.Log(magnitude);
        if (magnitude <= MeleeRange)
        {
            rb.velocity = Vector2.zero;
            enemy.Attack();
            animator.SetFloat("Speed", 0);
        }
        //else move towards player
        else
            MoveToPlayer();
    }
    private void MoveToPlayer()
    {
        //calculate player position
        Vector2 enemyPos = transform.position;
        Vector2 direction = playerPosition - enemyPos;
        float magnitude = direction.magnitude;
        direction.Normalize();

        //enemy movement
        Vector2 velocity = direction * enemy.GetMoveSpeed();
        if (!canFly)
            rb.velocity = new Vector2(velocity.x, rb.velocity.y);
        else
            rb.velocity = new Vector2(velocity.x, velocity.y);
        //Debug.Log(rb.velocity.magnitude);

        if (playerPosition.x > transform.position.x)
            enemyPosition.eulerAngles = new Vector2(0, 180);
        else
            enemyPosition.eulerAngles = new Vector2(0, 0);

        //Handle movement animation
        animationSpeed = rb.velocity.magnitude;
        //Debug.Log(animationSpeed);
        animator.SetFloat("Speed", animationSpeed);


    }

    private void MoveAwayFromPlayer()
    {
        //calculate player position
        Vector2 enemyPos = transform.position;
        Vector2 direction = -(playerPosition - enemyPos);
        float magnitude = direction.magnitude;
        direction.Normalize();

        //enemy movement
        Vector2 velocity = direction * enemy.GetMoveSpeed();
        if (!canFly)
            rb.velocity = new Vector2(velocity.x, rb.velocity.y);
        else
            rb.velocity = new Vector2(velocity.x, velocity.y);

        //flip enemy 
        if (playerPosition.x > transform.position.x)
            enemyPosition.eulerAngles = new Vector2(0, 180);
        else
            enemyPosition.eulerAngles = new Vector2(0, 0);

        //Handle movement animation
        animationSpeed = rb.velocity.magnitude;
        //Debug.Log(animationSpeed);
        animator.SetFloat("Speed", animationSpeed);
    }

    private void TurnToEnemy()
    {
        if (playerPosition.x < transform.position.x)
            enemyPosition.eulerAngles = new Vector2(0, 180);
        else
            enemyPosition.eulerAngles = new Vector2(0, 0);
    }




}
