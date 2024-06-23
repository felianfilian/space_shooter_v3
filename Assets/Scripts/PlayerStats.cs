using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthAmount;
    [SerializeField] private GameObject explosionEffect;

    private float health;

    void Start()
    {
        health = maxHealth;
        healthAmount.fillAmount = health/maxHealth;
    }

    public void PlayerDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        healthAmount.fillAmount = health / maxHealth;
    }

    public void PlayerHealth(float amount) {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
