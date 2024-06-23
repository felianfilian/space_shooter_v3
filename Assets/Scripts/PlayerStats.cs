using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthAmount;

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
