using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class load : MonoBehaviour
{
    public GameObject ground;
    public GameObject otherGround;
    public GameObject bush;
    public GameObject castle;
    public GameObject walls;
    public GameObject otherWalls;

    private void Awake()
    {
        //SaveScript.LoadData();
        if (File.Exists(SaveScript.savePath))
        {
            Save save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(SaveScript.savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
                for (int i = 0; i < save.saveTags.Count; i++)
                {
                    Debug.Log("loopin");
                    Vector3 pos = new Vector3((float)save.savePositionsX[i], (float)save.savePositionsY[i], (float)save.savePositionsZ[i]);
                    Quaternion rot = new Quaternion((float)save.saveRotationsW[i], (float)save.saveRotationsX[i], (float)save.saveRotationsY[i], (float)save.saveRotationsZ[i]);
                    switch (save.saveTags[i])
                    {
                        case "ground":
                            Instantiate(ground, pos, rot);
                            break;
                        case "otherGround":
                            Instantiate(otherGround, pos, rot);
                            break;
                        case "bush":
                            Instantiate(bush, pos, rot);
                            break;
                        case "castle":
                            Instantiate(castle, pos, rot);
                            break;
                        case "walls":
                            Instantiate(walls, pos, rot);
                            break;
                        case "otherWalls":
                            Instantiate(otherWalls, pos, rot);
                            break;
                        default:
                            Debug.Log("no tag");
                            break;
                    };

                }
            }
        }
        else
        {
            Debug.Log("savePath did not exist");
        }
        Destroy(this);//there would be multiple copies of this object with each save without this.
    }
}
