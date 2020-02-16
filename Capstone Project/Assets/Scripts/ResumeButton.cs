using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButton : MonoBehaviour
{
    public void Resume()
    {
        SaveScript.resume = true;//this is spaghetti
        SceneManager.LoadScene("Start");
    }
}
