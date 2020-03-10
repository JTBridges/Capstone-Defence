using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landingSpawn : MonoBehaviour
{
    public GameObject ground;
    public GameObject otherGround;
    public GameObject bush;
    public GameObject walls;
    public GameObject otherWalls;
    public float valueGround;

    void Start()
    {
        for (int i = 0; i <= 100; i += 2)
        {
            for (int j = 0; j <= 60; j += 2)
            {
                if (i == 0 || i == 100 || j == 60)
                {
                    Instantiate(walls, new Vector3(i, 3, j), Quaternion.identity, this.transform);
                    Instantiate(otherWalls, new Vector3(i, 5, j), Quaternion.identity, this.transform);
                }
                else
                {
                    if(j > 10 && valueGround > 0.97)
                    {
                        Instantiate(bush, new Vector3(i, 3, j), Quaternion.identity, this.transform);
                    }
                    valueGround = Random.value;
                    if (valueGround >= 0.5)
                        Instantiate(ground, new Vector3(i, 1, j), Quaternion.identity, this.transform);
                    else
                        Instantiate(otherGround, new Vector3(i, 1, j), Quaternion.identity, this.transform);
                }
            }
        }
    }
}
