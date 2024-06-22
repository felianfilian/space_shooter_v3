using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private float shotInterval;

    private float shotTimer;

    void Start()
    {
        shotTimer = shotInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;

        if(shotTimer <= 0)
        {
            shotTimer = shotInterval;
        }
    }
}
