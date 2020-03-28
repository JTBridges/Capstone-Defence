using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    public Transform cam;
    public GameObject MainCam;

    private void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera");

        cam = MainCam.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
