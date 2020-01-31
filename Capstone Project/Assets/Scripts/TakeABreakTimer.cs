using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TakeABreakTimer : MonoBehaviour
{
    Color c;
    // Start is called before the first frame update
    void Start()
    {
        c = this.GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        if (Time.time >= 15)
            this.GetComponent<Text>().color = new Color(c.r, c.g, c.b, 1);
    }
}
