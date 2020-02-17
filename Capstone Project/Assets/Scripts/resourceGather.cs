using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resourceGather : MonoBehaviour
{
    public Transform resourceTarget;
    public Text resourceAmount;
    public int resourceNumber;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tree"))
        {
            resourceTarget = other.gameObject.transform;
        }
    }

    public void getResource()
    {
        if(resourceTarget != null)
        {
            Destroy(resourceTarget.gameObject);
            resourceTarget = null;
            resourceNumber += 10;
            updateResources();
        }
    }

    public void removecannonResources(int subAmt)
    {
        resourceNumber -= subAmt;
        updateResources();
    }

    public int getcannonResources()
    {
        return resourceNumber;
    }

    void updateResources()
    {
        resourceAmount.text = resourceNumber.ToString();
    }



    /*Not currently working *Check Later*
     * void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Tree") && other.gameObject == resourceTarget)
        {
            resourceTarget = null;
        }
    }
        */
}
