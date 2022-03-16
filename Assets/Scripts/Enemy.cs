using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;
public abstract class Enemy : MonoBehaviour
{
    public enum Archetype { Melee, Ranged, Elite };
    //Enemy stats
    [SerializeField, FoldoutGroup("Stats")]
    protected string enemyName = "";
    [SerializeField, FoldoutGroup("Stats")]
    protected float currentHealth = 150.0f;
    [SerializeField, FoldoutGroup("Stats")]
    protected float maxHealth; //should be set to current health when enemy is created
    [SerializeField, FoldoutGroup("Stats")]
    protected float moveSpeed = 1.0f;
    [SerializeField, FoldoutGroup("Stats")]
    protected float attackDamage = 5.0f;

    public Archetype type;

    [SerializeField]
    protected Animator animator;
    protected Rigidbody2D rigidBody;

    protected virtual void Start()
    {
        maxHealth = currentHealth;
        rigidBody = GetComponent<Rigidbody2D>();
        Init();
    }

    //called by player when the player attack collider hits enemy and causes it to take damage
    public virtual void OnDamaged(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
            Die();
    }

    public virtual ref Rigidbody2D GetRigidbody2D()
    {
        return ref rigidBody;
    }

    public virtual float GetMoveSpeed()
    {
        return moveSpeed;
    }

    //Must at least set the enemy type
    protected abstract void Init();
    public abstract void Attack();
    public abstract void Die(); //when enemy dies


}
