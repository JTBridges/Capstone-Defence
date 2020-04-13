using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

//json class
[Serializable]
public class json
{
    public string fname;
    public string lname;
    public string status;
    public string uID;
    public string verification;
}


public class LoginAPI : MonoBehaviour
{
    //url for requests
    private string URL;
    //user inputs
    public string user;
    public string pass;
    //gameobjects for pointing 
    public GameObject username; //input field for username 
    public GameObject password; //input field for password 
    public GameObject LoginStatus; //displays login message
    //json init
    public json toField;


    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    //gets inputs from fields 
    public void getInput()
    {
        user = username.GetComponent<Text>().text;
        pass = password.GetComponent<InputField>().text;
    }

    //login request honestly this isn't the most secure rather standard but it works
    //I will try configuring API to handle post requests but I have been getting errors 
    public void Request()
    {
        URL = "http://34.66.171.142:5000/login?username=" + user + "&password=" + pass;
        WWW request = new WWW(URL);
        StartCoroutine(OnReponse(request));
    }

    //request handler
    IEnumerator OnReponse(WWW req)
    {
        yield return req;
        try
        {
            procJsonData(req.text);
            Login session = new Login();
            session.toLanding();
        }
        catch (Exception e)
        {
            LoginStatus.GetComponent<Text>().text = req.text;
        }
        /*using (UnityWebRequest webRequest = UnityWebRequest.Get(req))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = req.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                LoginStatus.GetComponent<Text>().text = "Network Error!";
            }
            else
            {
                try
                {
                    procJsonData(webRequest.downloadHandler.text);
                    Login session = new Login();
                    session.toLanding();
                }
                catch
                {
                    LoginStatus.GetComponent<Text>().text = webRequest.downloadHandler.text;
                }

            }

        }*/
    }

    private void procJsonData(string URL)
    {
        toField = JsonUtility.FromJson<json>(URL);
        LoginStatus.GetComponent<Text>().text = "Welcome, " + toField.fname;
    }
}

