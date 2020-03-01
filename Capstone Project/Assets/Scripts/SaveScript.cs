using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveScript
{
    private static string savePath = Application.persistentDataPath + "/gamesave.save";
    public static bool resume = false;//this is spaghetti

    public static void SaveData()
    {
        int sizeGround = GameObject.Find("WorldPrefabs").GetComponent<WorldPrefabs>().GroundList.Count;
        int[] groundTemp = new int[sizeGround];
        for(int i = 0; i < sizeGround; i++)
        {
            groundTemp[i] = GameObject.Find("WorldPrefabs").GetComponent<WorldPrefabs>().GroundList[i];
        }

        int sizeItem = GameObject.Find("WorldPrefabs").GetComponent<WorldPrefabs>().ItemList.Count;
        int[] itemTemp = new int[sizeItem];
        for(int i = 0; i < sizeItem; i++)
        {
            itemTemp[i] = GameObject.Find("WorldPrefabs").GetComponent<WorldPrefabs>().ItemList[i];
        }

        var save = new Save()
        {
            avatarPosX = GameObject.Find("LichAndCam").transform.position.x,
            avatarPosY = GameObject.Find("LichAndCam").transform.position.y,
            avatarPosZ = GameObject.Find("LichAndCam").transform.position.z,

            groundArr = groundTemp,
            itemArr = itemTemp
            
        };

        var binForm = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binForm.Serialize(fileStream, save);
        }
    }

    public static void LoadData()
    {
        Debug.Log("LoadData called");

        GameObject[] gameObjects = UnityEngine.SceneManagement.SceneManager.GetSceneByName("StartV2").GetRootGameObjects();
        Debug.Log(gameObjects.Length);
        if (File.Exists(savePath))
        {
            Save save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
                Vector3 vec = new Vector3(save.avatarPosX, save.avatarPosY, save.avatarPosZ);
                foreach(GameObject obj in gameObjects)//this won't work for the entire scene
                {
                    if (obj.name == "LichAndCam")
                    {
                        obj.transform.position = vec;
                    }
                }
                foreach(int i in save.groundArr)
                {
                    
                }
            }
        }
        else
        {
            Debug.Log("savePath did not exist");
        }
    }
}
