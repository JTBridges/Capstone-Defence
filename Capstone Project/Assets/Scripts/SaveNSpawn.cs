﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


//this class is a heavily modified mash up of WorldPrefabs.cs and SaveScript.cs
public  class SaveNSpawn: MonoBehaviour
{
    private string savePath;
    private void Awake()
    {
        savePath = Application.persistentDataPath + "/gamesave.save";
    }
    /*private void Start()
    {
       if(NewOrLoad.Load)
       {
            LoadData();
       }
       else
       {
            Debug.Log("hello? should be making new world");
            createWorld();
       }
    }*/

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
    public List<GameObject> Objective;
    public GameObject Spawner;
    public int worldNumber;

    private List<int> ItemList = new List<int>(1000);
    private List<int> GroundList = new List<int>(1000);
    private int listInc = 1;
    private int listInc2 = 1;

    private void createWorld()
    {

        for (int i = 0; i <= 100; i += 2)
        {
            for (int j = 0; j <= 100; j += 2)
            {
                if (i == 0 || i == 100 || j == 100 || j == 0)
                {
                    spawnTerrain(selectTerrain(4), i, 3, j);
                    spawnTerrain(selectTerrain(5), i, 5, j);
                }
                else if (i == 50 && j == 50)
                {
                    spawnTerrain(selectTerrain(20), i, 2, j);
                    int groundType = GroundWeight();
                    spawnTerrain(selectTerrain(groundType), i, 1, j);
                    AddToGroundList(groundType);
                }
                else if ((i >= 44 && i <= 56) && (j >= 44 && j <= 56))
                {
                    int groundType = GroundWeight();
                    spawnTerrain(selectTerrain(groundType), i, 1, j);
                    AddToGroundList(groundType);
                }
                else
                {
                    int groundType = GroundWeight();
                    if (groundType == 3)
                    {
                        spawnTerrain(selectTerrain(groundType), i, 1, j);
                        spawnTerrain(Spawner, i, 2, j);
                    }
                    else
                    {
                        spawnTerrain(selectTerrain(groundType), i, 1, j);
                    }

                    AddToGroundList(groundType);
                    int groundItemChance = SpawnChance(1, 999);
                    if (groundItemChance >= 970)
                    {
                        int item = SpawnChance(8, 19);
                        if (worldNumber == 1) //Desert
                        {
                            spawnTerrain(selectTerrain(item), i, SpawnDesertHeight(item), j);
                        }
                        else
                        {
                            spawnTerrain(selectTerrain(item), i, SpawnForestHeight(item), j);
                        }
                        AddToItemList(item);
                    }
                    else
                    {
                        int item = 0;//signifying a non-item.
                        AddToItemList(item);
                    }
                }
            }
        }
    }
    private int GroundWeight()
    {
        int ChanceToSpawn = SpawnChance(1, 10);
        int EnemySpawn = SpawnChance(1, 1000);
        if (EnemySpawn >= 995)
        {
            return 3;
        }
        else
        {
            if (listInc2 < 5)
            {
                return 1;
            }
            else
            {
                if (GroundList[listInc2 - 1] == 1)
                {
                    if (GroundList[listInc2 - 2] == 1)
                    {
                        if (GroundList[listInc2 - 3] == 1)
                        {
                            if (ChanceToSpawn <= 4)
                            {
                                return 1;
                            }
                            else
                            {
                                return 2;
                            }
                        }
                        if (ChanceToSpawn <= 7)
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    if (ChanceToSpawn <= 9)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }

                }
                if (GroundList[listInc2 - 1] == 2)
                {
                    if (GroundList[listInc2 - 2] == 2)
                    {
                        if (GroundList[listInc2 - 3] == 2)
                        {
                            if (ChanceToSpawn <= 3)
                            {
                                return 2;
                            }
                            else
                            {
                                return 1;
                            }
                        }
                        if (ChanceToSpawn <= 6)
                        {
                            return 2;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    if (ChanceToSpawn <= 8)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }

                }
            }
        }
        return 1;
    }

    private void AddToItemList(int x)
    {
        ItemList.Add(x);
        listInc++;

    }
    private void AddToGroundList(int x)
    {
        GroundList.Add(x);
        listInc2++;
    }

    private int SpawnChance(int min, int max)
    {
        return Random.Range(min, max);
    }

    /*
     * 1 - Ground1
     * 2 - Ground2
     * 3 - Spawn Ground
     * 4 - Wall1
     * 5 - Wall2
     * 6 - Bridge
     * 7 - Bridge Wide
     * 8 - Barrel
     * 9 - Grass1
     * 10 - Grass2
     * 11 - Wood Box
     * 12 - appleTreeShort
     * 13 - appleTreeTall
     * 14 - roundTreeShort
     * 15 - roundTreeTall
     * 16 - pineTreeShort
     * 17 - pineTreeShort2
     * 18 - pineTreeTall
     * 19 - pineTreeTall2
     * 20 - null
     * 
     */

    private float SpawnDesertHeight(int item)
    {
        switch (item)
        {
            case 8:
                return 2;
            case 9:
                return 2;
            case 10:
                return 2;
            case 11:
                return 3.6f;
            case 12:
            case 14:
            case 16:
            case 17:
                return 2.4f;
            case 13:
            case 15:
            case 18:
            case 19:
                return 2.7f;
            default:
                return 2;
        }
    }
    private float SpawnForestHeight(int item)
    {
        switch (item)
        {
            case 8:
                return 2.8f;
            case 11:
                return 2.52f;
            case 16:
                return 3;
            case 17:
                return 4;
            case 18:
                return 3;
            case 19:
                return 4;
            default:
                return 2;
        }
    }


    private GameObject selectTerrain(int x)
    {
        switch (x)
        {
            case 1:
                return ground1[worldNumber];
            case 2:
                return ground2[worldNumber];
            case 3:
                return spawnGround[worldNumber];
            case 4:
                return Wall1[worldNumber];
            case 5:
                return Wall2[worldNumber];
            case 6:
                return Bridge[worldNumber];
            case 7:
                return BridgeWide[worldNumber];
            case 8:
                return Barrel[worldNumber];
            case 9:
                return grass1[worldNumber];
            case 10:
                return grass2[worldNumber];
            case 11:
                return woodBox[worldNumber];
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
            case 20:
                return Objective[worldNumber];
            default:
                return ground2[worldNumber];
        }
    }

    private void spawnTerrain(GameObject obj, float x, float y, float z)
    {
        Instantiate(obj, new Vector3(x, y, z), Quaternion.identity, this.transform);     
    }

    private void SaveData()
    {
        Transform avatarTrans = GameObject.Find("LichAndCam").transform;
        var save = new Save()
        {
            avatarPosX = avatarTrans.position.x,
            avatarPosY = avatarTrans.position.y,
            avatarPosZ = avatarTrans.position.z,

            avatarRotW = avatarTrans.rotation.w,
            avatarRotX = avatarTrans.rotation.x,
            avatarRotY = avatarTrans.rotation.y,
            avatarRotZ = avatarTrans.rotation.z,

            groundArr = GroundList.ToArray(),
            itemArr = ItemList.ToArray()
        };
        var binForm = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binForm.Serialize(fileStream, save);
        }
    }
    private void LoadData()
    {
        if (File.Exists(savePath))
        {
            GameObject lichAndCam = GameObject.Find("LichAndCam");
            GameObject instantiator = GameObject.Find("Instantiator");
            Save save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
                Vector3 vec = new Vector3(save.avatarPosX, save.avatarPosY, save.avatarPosZ);
                Quaternion rot = new Quaternion(save.avatarRotW, save.avatarRotX, save.avatarRotY, save.avatarRotZ);
                lichAndCam.transform.position = vec;
                lichAndCam.transform.rotation = rot;
            }
            for(int i = 0; i < save.groundArr.Length; i++)
            {
                spawnTerrain(selectTerrain(save.groundArr[i]), 2 * ((i / 50) + 1), 0, 2 * ((i - 1) % 49) + 2);
            }
            for (int i = 0; i < save.itemArr.Length; i++)
            {
                spawnTerrain(selectTerrain(save.itemArr[i]), 2 * ((i / 50) + 1), 0, 2 * ((i - 1) % 49) + 2);
            }
        }
        else
        {
            Debug.Log("savePath did not exist");
        }
    }
}