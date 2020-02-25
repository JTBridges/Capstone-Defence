using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPrefabs : MonoBehaviour
{
    public List<GameObject> Barrel;
    public List<GameObject> Wall1;
    public List<GameObject> Wall2;
    public List<GameObject> Bridge;
    public List<GameObject> BridgeWide;
    public List<GameObject> woodBox;
    public List<GameObject> grass1;
    public List<GameObject> grass2;
    public List<GameObject> ground1;
    public List<GameObject> ground2;
    public List<GameObject> spawnGround;
    public List<GameObject> appleTreeShort;
    public List<GameObject> appleTreeTall;
    public List<GameObject> roundTreeShort;
    public List<GameObject> roundTreeTall;
    public List<GameObject> pineTreeShort;
    public List<GameObject> pineTreeShort2;
    public List<GameObject> pineTreeTall;
    public List<GameObject> pineTreeTall2;
    public GameObject Spawner;

    public int worldNumber = 1;

    public float valueGround;
    public float decider;

    List<int> list1 = new List<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 100; i += 2)
        {
            for (int j = 0; j <= 100; j += 2)
            {
                valueGround = Random.value;
                decider = Random.value;
                if (i == 0 || i == 100 || j == 0 || j == 100)
                {
                    Instantiate(Wall1[worldNumber], new Vector3(i, 3, j), Quaternion.identity, this.transform);
                    Instantiate(Wall2[worldNumber], new Vector3(i, 5, j), Quaternion.identity, this.transform);

                }
                else
                {
                    if (valueGround >= .5)
                    {
                        if (valueGround >= .95 && valueGround < 1)
                        {

                            if (valueGround >= .97 && decider >= .97)
                            {
                                Instantiate(spawnGround[worldNumber], new Vector3(i, 1, j), Quaternion.identity, this.transform);
                                Instantiate(Spawner, new Vector3(i, 1.75f, j), Quaternion.identity, this.transform);
                            }
                            else
                            {
                                Instantiate(appleTreeShort[worldNumber], new Vector3(i, 3, j), Quaternion.identity, this.transform);
                            }

                        }
                        Instantiate(ground1[worldNumber], new Vector3(i, 1, j), Quaternion.identity, this.transform);
                    }
                    else
                    {
                        Instantiate(ground2[worldNumber], new Vector3(i, 1, j), Quaternion.identity, this.transform);
                    }
                }
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
