using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;

    void Start()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        // hurt animation
        if(health <= 0)
        {
            health = 0;
            // destroy animation
        }
    }
}
