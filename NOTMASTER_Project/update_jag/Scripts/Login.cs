using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Login : MonoBehaviour
{   //takes user to login page
    public void toLogin()
    {
        SceneManager.LoadScene("LogIn");
    }
    //takes user to landing screen w/o parameters 
    public void toLanding()
    {
        SceneManager.LoadScene("Landing");
    }

}

