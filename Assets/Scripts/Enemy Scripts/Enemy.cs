using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected GameObject explosionEffect;

    [SerializeField] protected float damage;
    [SerializeField] protected float health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        HurtSequence();
        if(health <= 0)
        {
            health = 0;
            DeathSequence();
        }
    }

    public virtual void HurtSequence()
    {

    }

    public virtual void DeathSequence()
    {

    }
}
