using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonSelection : MonoBehaviour
{
    public GameObject cannon;
    public GameObject cannonPoint;

    private void Start()
    {
        //cannon = (GameObject)Resources.Load(("Assets / TowerDefence_Vsquad / Prefabs / HM_cannon_1.prefab"), typeof(GameObject));
        cannonPoint = GameObject.FindGameObjectWithTag("TowerPoint");
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
