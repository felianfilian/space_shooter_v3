using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteorType;
    [SerializeField] private float spawnTime;

    private float timer;
    private int meteorIndex;

    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    void Start()
    {
        spawnTime = 2;
        timer = 0;

        mainCam = Camera.main;
        StartCoroutine(SetBoundries());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime) {
            meteorIndex = Random.Range(0, meteorType.Length);
            GameObject obj = Instantiate(meteorType[meteorIndex], new Vector3(Random.Range(maxLeft, maxRight), yPos, -5), Quaternion.Euler(0,0,Random.Range(0, 360)));
            float size = Random.Range(0.9f, 1.1f);
            obj.transform.localScale = new Vector3(size, size, 0);
            timer = 0;
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
