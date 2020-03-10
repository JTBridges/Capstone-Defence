using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveSystem : MonoBehaviour
{

    public GameObject nextWaveButton;
    public Text waveText;
    public Text enemiesRemaining;
    private int waveTextAmount;
    private int enemiesRemainingAmount;
    private bool canEnemiesSpawn;
    public int Spawned;
    
    void Start()
    {
        canEnemiesSpawn = false;
        waveTextAmount = 0;
        nextWaveButton.SetActive(true);
    }

    
    void Update()
    {
        enemiesRemaining.text = "Enemies Remaining: " + enemiesRemainingAmount.ToString();
    }

    public void waveStart()
    {
        nextWaveButton.SetActive(false);
        waveTextAmount++;
        waveText.text = "Wave: " + waveTextAmount.ToString();
        setEnemies();
        canEnemiesSpawn = true;
    }

    public void incrementSpawn()
    {
        Spawned++;
    }

    public int getSpawned()
    {
        return Spawned;
    }

    public void setEnemies()
    {
        enemiesRemainingAmount = waveTextAmount * 5;
    }

    public bool getEnemySpawn()
    {
        return canEnemiesSpawn;
    }

    public int getEnemyRemaining()
    {
        return enemiesRemainingAmount;
    }

    public void removeEnemyAmount()
    {
        enemiesRemainingAmount--;
    }
}
