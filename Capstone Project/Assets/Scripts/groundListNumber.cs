using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundListNumber : MonoBehaviour
{
    private GameObject WorldSpawn;
    public int objectNumber;
    
    void Start()
    {
        WorldSpawn = GameObject.FindGameObjectWithTag("WorldSpawner");
        objectNumber = WorldSpawn.GetComponent<WorldPrefabs>().GetGroundList();
    }

}
