using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonSelection : MonoBehaviour
{
    public GameObject cannon;
    public GameObject cannonPoint;
    private Transform theposition;

    private void Start()
    {
        cannon = Instantiate(Resources.Load("Cannon1", typeof(GameObject))) as GameObject; //This gives an error and that is what we want
        cannonPoint = GameObject.FindGameObjectWithTag("TowerPoint");
        theposition = cannonPoint.transform;
    }

    private void FixedUpdate()
    {


        cannonPoint = GameObject.FindGameObjectWithTag("TowerPoint");
    }

    public void SpawnCannon()
    {
        Transform theposition = cannonPoint.transform;
        Instantiate(cannon, theposition.position, theposition.rotation);
    }
}
