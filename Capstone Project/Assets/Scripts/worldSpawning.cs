using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldSpawning : MonoBehaviour
{
    /*public GameObject ground;
    public GameObject otherGround;
    public GameObject bush;
    public GameObject castle;
    public GameObject walls;
    public GameObject otherWalls;
    public float valueGround;
    public float decider;

    void Start()
    {
        for(int i=0; i<=100; i+=2)
        {
            for (int j = 0; j <= 100; j += 2)
            {
                valueGround = Random.value;
                decider = Random.value;
                if (i == 0 || i == 100 || j == 0 || j == 100)
                {
                    Instantiate(walls, new Vector3(i, 3, j), Quaternion.identity, this.transform);
                    Instantiate(otherWalls, new Vector3(i, 5, j), Quaternion.identity, this.transform);

                }
                else
                {
                    if (valueGround >= .5)
                    {
                        if (valueGround >= .95 && valueGround < 1)
                        {

                            if (valueGround >= .97 && decider >= .97)
                            {
                                Instantiate(castle, new Vector3(i, 1.75f, j), Quaternion.identity, this.transform);
                                
                            }
                            else
                            {
                                Instantiate(bush, new Vector3(i, 3, j), Quaternion.identity, this.transform);
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
    */

}
