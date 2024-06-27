using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy02: Enemy
{
    [Header("Main Stats")]
    [SerializeField] private float speed;

    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }


    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("dmg"))
        {
            return;
        }
        anim.SetTrigger("damage");
    }

    public override void DeathSequence()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            player.PlayerDamage(damage);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
