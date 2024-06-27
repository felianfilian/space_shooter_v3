using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("Enemy Prefabs")]
    [SerializeField] GameObject[] enemy;
    [Space(15)]
    [SerializeField] private float spawnTime;

    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;
    private float spawnCounter;

    void Start()
    {
        spawnCounter = 0;
        spawnTime = 2;
        mainCam = Camera.main;
        StartCoroutine(SetBoundries());
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        spawnCounter += Time.deltaTime;
        if (spawnCounter >= spawnTime)
        {
            int randomEnemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[randomEnemy], new Vector3(Random.Range(maxLeft, maxRight), yPos, 0), Quaternion.identity);
            spawnCounter = 0;
        }
    }

    private IEnumerator SetBoundries()
    {
        yield return new WaitForSeconds(0.4f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}
