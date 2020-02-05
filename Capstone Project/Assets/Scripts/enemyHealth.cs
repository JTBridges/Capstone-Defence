using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int Health = 30;

    public void Damage(int dmg)
    {
        Health -= dmg;
    }

    void Update()
    {
        if(Health <= 0)
        {
            gameObject.tag = "Dead";   //This will change the tag so that the tower can see that its dead
        }
    }
}
