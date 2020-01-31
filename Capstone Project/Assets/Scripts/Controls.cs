using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float speed = 15;
    public float lookSensitivity = 5;
    private Vector3 displacement = new Vector3(0,0,0);
    private bool isMoving;
    private Transform cameraTransform;
    private Transform lichTransform;
    private int zoomDisplacement = 0;
    private Joystick[] sticks;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform.GetChild(1).transform;
        lichTransform = transform.GetChild(0).transform;
        sticks = FindObjectsOfType<Joystick>();
        anim = GetComponent<Animator>();
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
           transform.Translate(vec * speed * Time.deltaTime);//don't change transform.position directly
           transform.Rotate(0, sticks[0].Horizontal * lookSensitivity, 0);
   #endif
   #if UNITY_STANDALONE || UNITY_EDITOR

           transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
           //cameraTransform.Rotate(Input.GetAxis("Mouse Y") * lookSensitivity, 0, 0);

           displacement = new Vector3(0, 0, 0);

           if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
               displacement.z += 1;

           if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
               displacement.x -= 1;

           if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
               displacement.z -= 1;

           if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
               displacement.x += 1;

           if (Input.GetAxis("Mouse ScrollWheel") > 0f)
           {
               if (zoomDisplacement < 3)
               {
                   zoomDisplacement++;
                   cameraTransform.position += cameraTransform.forward;
               }
           }
           else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
           {
               if (zoomDisplacement > -10)
               {
                   zoomDisplacement--;
                   cameraTransform.position -= cameraTransform.forward;
               }
           }

           if (displacement != Vector3.zero)
               anim.SetBool("isMoving", true);

           Vector3.Normalize(displacement);//without this diagnol movement would be faster
           transform.Translate(displacement * Time.deltaTime * speed);//don't change transform.position directly, it would enable walking through walls.
  #endif
    }
}
