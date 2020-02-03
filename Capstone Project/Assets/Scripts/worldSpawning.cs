using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldSpawning : MonoBehaviour
{
    public GameObject ground;
    public GameObject otherGround;
    public GameObject bush;
    public GameObject castle;
    public float valueGround;
    public float decider;

    void Start()
    {
        for(int i=0; i<=100; i+=2)
        {
            for(int j=0; j<=100; j+=2)
            {
                valueGround = Random.value;
                decider = Random.value;
                if(valueGround >= .5)
                {
                    if(valueGround >= .95 && valueGround < 1)
                    {
                        Instantiate(bush, new Vector3(i, 2, j), Quaternion.identity, this.transform);
                        if(valueGround >= .97 && decider >= .97)
                        {
                            Instantiate(castle, new Vector3(i, 2, j), Quaternion.identity, this.transform);
                        }
                    }
                    Instantiate(ground, new Vector3(i, 1, j), Quaternion.identity, this.transform);
                }
                else
                {
                    Instantiate(otherGround, new Vector3(i, 1, j), Quaternion.identity, this.transform);
                }
            }
            
        }
            
    }


}
