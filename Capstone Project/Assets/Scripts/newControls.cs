using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newControls : MonoBehaviour
{

    private Joystick[] sticks;
    private Rigidbody body;

    public float speed;
    public float rotationspeed;
    public float vertical;
    public float horizontal;


    void Start()
    {
        sticks = FindObjectsOfType<Joystick>();
        body = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        vertical = sticks[1].Vertical;
        horizontal = sticks[1].Horizontal;
        body.velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
        transform.Rotate((transform.up * horizontal) * rotationspeed * Time.fixedDeltaTime);
    }
}
