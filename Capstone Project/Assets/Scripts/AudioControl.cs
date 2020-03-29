using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public void Awake()
    {
        check();
        GameObject.Find("Audio Source").transform.GetComponent<AudioSource>().volume = StaticStuff.volume;
    }
    public void off()
    {
        StaticStuff.music = false;
        check();
    }
    public void on()
    {
        StaticStuff.music = true;
        check();
    }
    public void check()
    {
       if(StaticStuff.music == false)
       {
            GameObject.Find("Audio Source").transform.GetComponent<AudioSource>().mute = true;
       }
       else if(StaticStuff.music == true)
       {
            GameObject.Find("Audio Source").transform.GetComponent<AudioSource>().mute = false;
       }
    }
    public void onValueChanged(float value)
    {
        StaticStuff.volume = value;
        GameObject.Find("Audio Source").transform.GetComponent<AudioSource>().volume = value;
    }
}
