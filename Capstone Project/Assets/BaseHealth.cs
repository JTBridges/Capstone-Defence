using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseHealth : MonoBehaviour
{
    public GameObject loginManager;
    public GameObject Manager;
    public GameObject ResourceManager;
    private string verification;
    private string UID;
    private string waves;
    private string kills;
    public int Health = 100;
    public HealthBar healthbar;
    public string URL;

    void Start()
    {
        try
        {
            loginManager = GameObject.FindGameObjectWithTag("loginManager");
        }
        catch
        {
            Debug.Log("No Login Manager");
        }
        healthbar.SetMaxHealth(Health);
        Manager = GameObject.FindGameObjectWithTag("Manager");
        ResourceManager = GameObject.FindGameObjectWithTag("resourceTarget");       
        verification = loginManager.GetComponent<LoginAPI>().toField.verification;
        UID = loginManager.GetComponent<LoginAPI>().toField.uID;

    }

    public void Damage(int dmg)
    {
        Health -= dmg;

        healthbar.SetHealth(Health);
    }

    private void Update()
    {
        if(Health <= 0)
        {
            LeaderBoardUpdate();
            Destroy(gameObject, 1f);
            SceneManager.LoadScene("Game Over");
        }
    }

    private void LeaderBoardUpdate()
    {
        Debug.Log("The game has ended");
        kills = ResourceManager.GetComponent<resourceGather>().GetMonstersKilled();
        waves = Manager.GetComponent<waveSystem>().waves();
        URL = "http://34.66.171.142:5000/leaderboards/update?verification=" + verification + "&userid=" + UID + "&score=" + waves + "&kills=" + kills;
        WWW request = new WWW(URL);
        StartCoroutine(EndGame(request));
    }

    //request handler
    IEnumerator EndGame(WWW req)
    {
        yield return req;
    }
    }
