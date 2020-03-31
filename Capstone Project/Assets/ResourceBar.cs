using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    public Slider slider;

    public void SetAmount(int resources)
    {
        slider.value = resources;
    }

    public void SetMaxAmount(int resources)
    {
        slider.maxValue = resources;
    }
}
