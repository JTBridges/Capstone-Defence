using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameButtonScript : MonoBehaviour
{
    public void NewGame()
    {
        NewOrLoad.Load = false;
        SceneManager.LoadScene("Start");
    }
}
