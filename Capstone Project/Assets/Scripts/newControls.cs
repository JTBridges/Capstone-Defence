using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newControls : MonoBehaviour
{
    public GameObject rightStick;
    public GameObject leftStick;
    public Joystick[] sticks;
    private Rigidbody body;
    private Animator anim;

    public GameObject player;



    public float speed;
    public float rotationspeed;
    public float vertical;
    public float horizontal;
    public float strafe;




    void Start()
    {
        //sticks = FindObjectsOfType<Joystick>();
        body = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    
    void Update()
    {
        if (vertical != 0)
        {
            if (vertical >= .5)
            {
                anim.SetBool("isRunning", true);
                //player.transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            else if (vertical < 0)
            {
                if(vertical <= -.5)
                {
                    anim.SetBool("isRunning", true);
                }
                anim.SetBool("isMoving", true);
                //.transform.rotation = Quaternion.Euler(0, 180, 0);

            }
            else
            {
                anim.SetBool("isMoving", true);
                //player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isMoving", false);
        }
        /*if (strafe <= -.4 || strafe >= .4)
        {
            if(strafe >= .5)
            {
                anim.SetBool("isRunning", true);
                player.transform.rotation = Quaternion.Euler(0, 90, 0);

            }
            else if (strafe < 0)
            {
                if (strafe <= -.5)
                {
                    anim.SetBool("isRunning", true);
                }
                anim.SetBool("isMoving", true);
                player.transform.rotation = Quaternion.Euler(0, -90, 0);

            }
            else
            {
                anim.SetBool("isMoving", true);
                player.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isMoving", false);
        }*/
    }

    void FixedUpdate()
    {
        vertical = sticks[1].Vertical;
        strafe = sticks[1].Horizontal;
        horizontal = sticks[0].Horizontal;


        Vector3 velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
        velocity.y = body.velocity.y;
        body.velocity = velocity;
        transform.Rotate((transform.up * horizontal) * rotationspeed * Time.fixedDeltaTime);
    }
}
