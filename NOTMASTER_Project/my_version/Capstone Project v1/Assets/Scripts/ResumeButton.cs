using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButton : MonoBehaviour
{
    public void Resume()
    {
        NewOrLoad.Load = true;
        SceneManager.LoadScene("Start");
    }
}
