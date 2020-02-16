using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaghettiResume : MonoBehaviour
{
    private void Awake()
    {
        if (SaveScript.resume == true)
        {
            SaveScript.LoadData();
        }
    }
}
