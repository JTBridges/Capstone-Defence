﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public float randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        randomNumber = Random.value;

        if (randomNumber >= .5)
        {
            Instantiate(enemy1, this.transform);

        }
        else
        {
            Instantiate(enemy2, this.transform);

        }
    }
}