using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    

    [Header("Enemy Prefabs")]
    [SerializeField] GameObject[] enemy;
    [Space(15)]
    [SerializeField] private float spawnCounter;

    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;
    private float spawnTimer;

    void Start()
    {
        spawnTimer = 4;
        mainCam = Camera.main;
        StartCoroutine(SetBoundries());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SetBoundries()
    {
        yield return new WaitForSeconds(0.4f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}
