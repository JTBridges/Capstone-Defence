using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject Manager;
    public float randomNumber;
    private bool Spawn;
    private int EnemyRemaining;
    public int EnemySpawned;
    public float SpawnTimer = 10;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        
        //InvokeRepeating("SpawnEnemy", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn = Manager.GetComponent<waveSystem>().getEnemySpawn();
        EnemyRemaining = Manager.GetComponent<waveSystem>().getEnemyRemaining();
        EnemySpawned = Manager.GetComponent<waveSystem>().getSpawned();
        SpawnTimer -= Time.deltaTime;
        if(SpawnTimer < 0 && Spawn == true && EnemyRemaining > 0)
        {
            SpawnEnemy();
            SpawnTimer = 10;
        }
    }

    void SpawnEnemy()
    {
        randomNumber = Random.value;

        if(EnemySpawned < EnemyRemaining)
        {
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
}
