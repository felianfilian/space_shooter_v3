using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private float shootInterval;
    [SerializeField] private Transform leftCanonSpawn;
    [SerializeField] private Transform rightCanonSpawn;
    [SerializeField] private GameObject bullet;

    private float shootTImer = 0f;

    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    
    void Update()
    {
        shootTImer += Time.deltaTime;
        if (shootTImer >= shootInterval)
        {
            Instantiate(bullet, leftCanonSpawn.position, Quaternion.identity);
            Instantiate(bullet, rightCanonSpawn.position, Quaternion.identity);
            shootTImer = 0;
        }
    }
}
