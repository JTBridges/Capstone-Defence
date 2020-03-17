using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public float avatarPosX;
    public float avatarPosY;
    public float avatarPosZ;

    public float avatarRotW;
    public float avatarRotX;
    public float avatarRotY;
    public float avatarRotZ;

    public int[] groundArr;
    public int[] itemArr;

    public int worldNumber;//the asthetic theme of the world
    public bool music;
    public float volume;
    public int logs;
    public int coins;
    public int kills;
    public int wave;
}
