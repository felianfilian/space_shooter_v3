using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private float winTime;
    [SerializeField] private GameObject[] spawner;

    private float timer;

    void Start()
    {
        winTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        if (timer >= winTime) 
        {
            for(int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }
        }
    }
}
