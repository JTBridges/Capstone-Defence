using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonSelection : MonoBehaviour
{
    public GameObject cannon;
    public GameObject cannonPoint;
    private Transform theposition;
    public GameObject resourceObject;
    public int cannonCost = 10;

    private void Start()
    {
        cannon = Instantiate(Resources.Load("Cannon1", typeof(GameObject))) as GameObject; //This gives an error and that is what we want
        cannonPoint = GameObject.FindGameObjectWithTag("TowerPoint");
        theposition = cannonPoint.transform;
        resourceObject = GameObject.FindGameObjectWithTag("resourceTarget");
    }

    private void FixedUpdate()
    {
        resourceObject = GameObject.FindGameObjectWithTag("resourceTarget");
        cannonPoint = GameObject.FindGameObjectWithTag("TowerPoint");
    }

    public void SpawnCannon()
    {
        int amt = resourceObject.GetComponent<resourceGather>().getcannonResources();
        if(amt >= cannonCost)
        {
            Transform theposition = cannonPoint.transform;
            Instantiate(cannon, theposition.position, theposition.rotation);
            resourceObject.GetComponent<resourceGather>().removecannonResources(cannonCost);
        }

        
    }
}
