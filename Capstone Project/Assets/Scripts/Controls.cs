﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float speed = 15;
    public float lookSensitivity = 5;
    private Vector3 displacement = new Vector3(0,0,0);
    private bool isMoving;
    private Transform camTrans;
    private Transform lichTrans;
    private int zoomDisplacement = 0;
    private Joystick[] sticks;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        lichTrans = transform.GetChild(0).transform;
        camTrans = transform.GetChild(1).transform;
        anim = transform.GetChild(0).GetComponent<Animator>();
        sticks = FindObjectsOfType<Joystick>();
    }

    // Update is called once per frame
    //lines starting with # are for platform dependent compilation.
    void Update()
    {
        anim.SetBool("isMoving", false);
    #if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
        Vector3 vec = new Vector3(sticks[1].Horizontal, 0, sticks[1].Vertical);
        if (vec != Vector3.zero)
            anim.SetBool("isMoving", true);
        Vector3.Normalize(vec);//otherwise diagnol movement would be faster
        lichTrans.forward = vec;
        transform.Translate(vec * speed * Time.deltaTime);//don't change transform.position directly
        camTrans.RotateAround(lichTrans.position, Vector3.up, sticks[0].Horizontal * lookSensitivity);
   #endif
   #if UNITY_STANDALONE || UNITY_EDITOR

        camTrans.RotateAround(lichTrans.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity);

        displacement = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            displacement += camTrans.forward;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            displacement -= camTrans.right;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            displacement -= camTrans.forward;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            displacement += camTrans.right;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (zoomDisplacement < 3)
            {
                zoomDisplacement++;
                camTrans.position += camTrans.forward;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (zoomDisplacement > -10)
            {
                zoomDisplacement--;
                camTrans.position -= camTrans.forward;
            }
        }

        displacement = Vector3.ProjectOnPlane(displacement, Vector3.up);//camera forward is actually slanted downwards
        Vector3.Normalize(displacement);//without this diagnol movement would be faster
        if (displacement != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
            lichTrans.forward = displacement;
        }
        transform.Translate(displacement * Time.deltaTime * speed);//don't change transform.position directly, it would enable walking through walls.
  #endif
    }
}