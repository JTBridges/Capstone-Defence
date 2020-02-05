using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newControls : MonoBehaviour
{

    private Joystick[] sticks;
    private Rigidbody body;
    private Animator anim;

    public float speed;
    public float rotationspeed;
    public float vertical;
    public float horizontal;




    void Start()
    {
        sticks = FindObjectsOfType<Joystick>();
        body = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    
    void Update()
    {
        if (vertical > 0)
        {
            if (vertical >= .5)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isMoving", true);
            }

        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isMoving", false);
        }
    }

    void FixedUpdate()
    {
        vertical = sticks[1].Vertical;
        horizontal = sticks[0].Horizontal;


        Vector3 velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
        velocity.y = body.velocity.y;
        body.velocity = velocity;
        transform.Rotate((transform.up * horizontal) * rotationspeed * Time.fixedDeltaTime);
    }
}
