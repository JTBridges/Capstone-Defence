using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int Health = 30;
    private Animator anim;
    private const float moveSpeed = .02f;
    public GameObject thePlayer;

    void Start()
    {
        anim = transform.GetComponent<Animator>();
        thePlayer = GameObject.FindGameObjectWithTag("Player");
    }

    public void Damage(int dmg)
    {
        Health -= dmg;
        anim.SetBool("getHit", true);
    }

    void Update()
    {
        if(Health <= 0)
        {
            gameObject.tag = "Dead";   //This will change the tag so that the tower can see that its dead
            anim.SetBool("isDead", true);
            Destroy(gameObject, 1f);
        }

        transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed);
        transform.LookAt(thePlayer.transform);
        anim.SetBool("movingForward", true);
 //       anim.SetBool("getHit", false);
    }
}
