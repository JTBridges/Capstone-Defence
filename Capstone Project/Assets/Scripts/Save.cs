using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    //apparently Vector3 isn't serializable
    public float avatarPosX;
    public float avatarPosY;
    public float avatarPosZ;
    //public Quaternion avatarRot;
}
