using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundListNumber : MonoBehaviour
{
    private GameObject WorldSpawn;
    public int objectNumber;
    // Start is called before the first frame update
    void Start()
    {
        WorldSpawn = GameObject.FindGameObjectWithTag("WorldSpawner");
        objectNumber = WorldSpawn.GetComponent<WorldPrefabs>().GetGroundList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
