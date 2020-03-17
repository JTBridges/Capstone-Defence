using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using static System.Net.Mime.MediaTypeNames;

public class SetText : MonoBehaviour
{
    public void onValueChanged(float value)
    {
        //float theme = GameObject.Find("Slider_Theme").GetComponent<Slider>().value;
        switch (value)
        {
            case 0:
                transform.GetChild(0).transform.GetComponent<UnityEngine.UI.Text>().text = "Theme: Forest";
                break;
            case 1:
                transform.GetChild(0).transform.GetComponent<UnityEngine.UI.Text>().text = "Theme: Desert";
                break;
            case 2:
                transform.GetChild(0).transform.GetComponent<UnityEngine.UI.Text>().text = "Theme: Dungeon";
                break;
            case 3:
                transform.GetChild(0).transform.GetComponent<UnityEngine.UI.Text>().text = "Theme: Winter";
                break;
        }
    }
}
