using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float health;

    void Start()
    {
        health = maxHealth;
    }

    public void PlayerDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void PlayerHealth(float amount) {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
