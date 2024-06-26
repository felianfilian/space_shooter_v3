using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthAmount;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private Animator anim;

    private float health;
    private bool canPlayAnimation = true;

    void Start()
    {
        health = maxHealth;
        healthAmount.fillAmount = health/maxHealth;
    }

    public void PlayerDamage(float amount)
    {
        health -= amount;
        if(canPlayAnimation)
        {
            anim.SetTrigger("damage");
            StartCoroutine(AntiSpamAnimation());
        }
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

    private IEnumerator AntiSpamAnimation()
    {
        canPlayAnimation = false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnimation = true;
    }
}
