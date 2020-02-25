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

    public int worldNumber = 0;

    public float valueGround;
    public float decider;

    public List<GameObject> list1 = new List<GameObject>(1000);
    
    void Start()
    {
        Debug.Log("1");
        createWorld();
        //list1.Add(selectTerrain(1));
    }

    public void createWorld()
    {
        int listNumber = 0;
        Debug.Log("2");

        for (int i = 0; i <= 100; i += 2)
        {
            Debug.Log("6");
            for (int j = 0; j <= 100; j += 2)
            {
                if (list1[listNumber] == null)
                {
                    Debug.Log("4");
                    if (i == 0 || i == 100 || j == 100 || j == 0)
                    {

                        spawnTerrain(selectTerrain(4), i, 3, j);

                        spawnTerrain(selectTerrain(5), i, 5, j);
                    }
                }
            }
        }
        Debug.Log("5");
    }

    /*
     * 1 - Ground1
     * 2 - Ground2
     * 3 - Barrel
     * 4 - Wall1
     * 5 - Wall2
     * 6 - Bridge
     * 7 - Bridge Wide
     * 8 - Wood Box
     * 9 - Grass1
     * 10 - Grass2
     * 11 - Spawn Ground
     * 12 - appleTreeShort
     * 13 - appleTreeTall
     * 14 - roundTreeShort
     * 15 - roundTreeTall
     * 16 - pineTreeShort
     * 17 - pineTreeShort2
     * 18 - pineTreeTall
     * 19 - pineTreeTall2
     * 
     */

    public GameObject selectTerrain(int x)
    {
        switch(x)
        {
            case 1:
                return ground1[worldNumber];
            case 2:
                return ground2[worldNumber];
            case 3:
                return Barrel[worldNumber];
            case 4:
                return Wall1[worldNumber];
            case 5:
                return Wall2[worldNumber];
            case 6:
                return Bridge[worldNumber];
            case 7:
                return BridgeWide[worldNumber];
            case 8:
                return woodBox[worldNumber];
            case 9:
                return grass1[worldNumber];
            case 10:
                return grass2[worldNumber];
            case 11:
                return spawnGround[worldNumber];
            case 12:
                return appleTreeShort[worldNumber];
            case 13:
                return appleTreeTall[worldNumber];
            case 14:
                return roundTreeShort[worldNumber];
            case 15:
                return roundTreeTall[worldNumber];
            case 16:
                return pineTreeShort[worldNumber];
            case 17:
                return pineTreeShort2[worldNumber];
            case 18:
                return pineTreeTall[worldNumber];
            case 19:
                return pineTreeTall2[worldNumber];
            default:
                return ground2[worldNumber];
        }
    }

    void spawnTerrain(GameObject obj, int x, int y, int z)
    {
        Instantiate(obj, new Vector3(x, y, z), Quaternion.identity, this.transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
