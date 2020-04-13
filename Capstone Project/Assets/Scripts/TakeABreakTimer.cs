using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TakeABreakTimer : MonoBehaviour
{
    public GameObject TakeABreak;
    private bool done = false;

    void Update()
    {
        Debug.Log("checking");
        if (Time.time >= 20 && !done)
        {
            TakeABreak.gameObject.SetActive(true);
            done = true;
        }
    }
}
