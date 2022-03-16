using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Animations;

using Sirenix.OdinInspector;

using GameManagement;

public class Arrow : MonoBehaviour
{

    [SerializeField]
    public float Speed = 1;

    [SerializeField]
    public float DropSpeed = 1;

    [SerializeField]
    public float Damage = 10;

    [SerializeField]
    public float SinkValue = 0.1f;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    AudioSource HitSound;

    [SerializeField]
    List<AudioClip> Sounds = new List<AudioClip>();


    public bool Hit;

    float FixeScale;

    private void Awake()
    {
        List<Collider2D> colliders = PlayerInfo.player.GetComponentsInChildren<Collider2D>(true).ToList();

        foreach (var item in colliders)
        {
            Physics2D.IgnoreCollision(item, GetComponent<Collider2D>());
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Hit)
            return;

        transform.position += transform.right * Speed * Time.deltaTime;
        transform.eulerAngles -= new Vector3(0, 0, DropSpeed * Time.deltaTime);

    }

    public void Reset()
    {
        transform.eulerAngles = new Vector3(0, 0, 0); ;
        Hit = false;
        rb.simulated = true;
    }

    public void Init()
    {
        transform.eulerAngles -= new Vector3(0, 180, 0);
    }

    virtual public void StickArrow(GameObject Parent)
    {
        HitSound.clip = Sounds[Random.Range(0, Sounds.Count)];
        HitSound.Play();

        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
        rb.simulated = false;
        Hit = true;

        transform.position += transform.right * SinkValue;

        transform.parent = Parent.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerAttack")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        else if (collision.collider.gameObject.GetComponent<ArrowInteractable>() != null)
        {

            HitSound.clip = Sounds[Random.Range(0, Sounds.Count)];
            HitSound.Play();

            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            rb.simulated = false;
            Hit = true;

            //transform.position += transform.right * SinkValue;
            //transform.parent = collision.collider.transform;

            StickArrow(collision.collider.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().OnDamaged(Damage);
        }
        if (collision.gameObject.tag == "EnemyAttack")
        {
            collision.gameObject.GetComponent<Enemy>().OnDamaged(Damage);
        }
        if (collision.gameObject.tag == "EnemyTop")
        {
            collision.gameObject.GetComponent<Enemy>().OnDamaged(Damage);
        }


    }


}

