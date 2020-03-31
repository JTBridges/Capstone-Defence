using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject SettingsPopup;

    public void NewGame()
    {
        SceneManager.LoadScene("Start");
    }
    public void Settings()
    {
        SettingsPopup.gameObject.SetActive(true);
    }
    public void CloseSettings()
    {
        SettingsPopup.gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
