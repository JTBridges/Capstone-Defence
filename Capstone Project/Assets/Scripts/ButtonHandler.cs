using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject SettingsPopup;

    public void NewGame()
    {
        NewOrLoad.Load = false;
        SceneManager.LoadScene("Start");
    }
    public void Settings()
    {
        SettingsPopup.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        SettingsPopup.transform.localScale = new Vector3(0.46f, 0.4f, 1);
        SettingsPopup.transform.position = new Vector2(960, 530);
    }
    public void CloseSettings()
    {
        SettingsPopup.transform.SetParent(null);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
