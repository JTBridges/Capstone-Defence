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
        var save = new Save()
        {
            avatarPosX = GameObject.Find("LichAndCam").transform.position.x,
            avatarPosY = GameObject.Find("LichAndCam").transform.position.y,
            avatarPosZ = GameObject.Find("LichAndCam").transform.position.z,
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

        GameObject[] gameObjects = UnityEngine.SceneManagement.SceneManager.GetSceneByName("Start").GetRootGameObjects();
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
            }
        }
        else
        {
            Debug.Log("savePath did not exist");
        }
    }
}
