using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAvatarScript : MonoBehaviour
{
    float speed = 15;
    float mouseSensitivity = 5;
    private Vector3 displacement = new Vector3(0,0,0);
    private bool isMoving;
    private Transform cameraTransform;
    private int zoomDisplacement = 0;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform.GetChild(2).transform;
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = false;

        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        //cameraTransform.Rotate(Input.GetAxis("Mouse Y") * mouseSensitivity, 0, 0);

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
            isMoving = true;
        
        Vector3.Normalize(displacement);//without this diagnol movement would be faster
        transform.Translate(displacement * Time.deltaTime * speed);//don't change transform.position directly, it would enable walking through walls.
    }
}
