using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Metroid : Enemy
{

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;

    void Start()
    {
        minSpeed = 8;
        maxSpeed = 15;
        speed = Random.Range(minSpeed, maxSpeed);

        rb.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HurtSequence()
    {
        
    }

    public override void DeathSequence()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        
    }
}
