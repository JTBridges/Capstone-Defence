using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//this saving system is almost certainly insecure
public static class SaveScript
{
    public static string savePath = Application.persistentDataPath + "/gamesave.save";
    public static bool isThereASave = false;
    
    public static void SaveData()
    {
        GameObject[] gameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        ArrayList tags = new ArrayList();
        ArrayList positionsX = new ArrayList();
        ArrayList positionsY = new ArrayList();
        ArrayList positionsZ = new ArrayList();
        ArrayList rotationsW = new ArrayList();
        ArrayList rotationsX = new ArrayList();
        ArrayList rotationsY = new ArrayList();
        ArrayList rotationsZ = new ArrayList();
        foreach (GameObject obj in gameObjects)
        {
            tags.Add(obj.tag);
            positionsX.Add(obj.transform.position.x);
            positionsY.Add(obj.transform.position.y);
            positionsZ.Add(obj.transform.position.z);
            rotationsW.Add(obj.transform.rotation.w);
            rotationsX.Add(obj.transform.rotation.x);
            rotationsY.Add(obj.transform.rotation.y);
            rotationsZ.Add(obj.transform.rotation.z);
        }

        var save = new Save()
        {
            saveTags = tags,
            savePositionsX = positionsX,
            savePositionsY = positionsY,
            savePositionsZ = positionsZ,
            saveRotationsW = rotationsW,
            saveRotationsX = rotationsX,
            saveRotationsY = rotationsY,
            saveRotationsZ = rotationsZ
        };

        var binForm = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binForm.Serialize(fileStream, save);
        }
    }
}
