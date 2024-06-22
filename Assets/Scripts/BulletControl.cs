using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float shootInterval;

    private float shootTimer;

    void Start()
    {
        shootTimer = shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;

        if(shootTimer <= 0)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, spawnPosition.position, Quaternion.identity);
            
    }
}
