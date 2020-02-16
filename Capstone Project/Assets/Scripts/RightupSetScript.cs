using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightupSetScript : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene("Landing");
        SaveScript.SaveData();
    }
}
