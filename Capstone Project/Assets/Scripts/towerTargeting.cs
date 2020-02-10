using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerTargeting : MonoBehaviour
{
    public Animator anim;
    public bool isDead = false;
    public Transform cannonPivot;
    public int towerHP;
    public Transform currentTarget;
    public Transform shootElement;
    public GameObject bullet;
    private float cannonRest;
    public int damageAmount = 10;
    public float shootDelay;
    bool shooting;
    public bool locked;

    void Start()
    {
        
        cannonPivot = transform.GetChild(0).GetChild(2).transform;
        shootElement = transform.GetChild(0).GetChild(2).GetChild(0).transform;
        anim = GetComponent<Animator>();
        cannonRest = cannonPivot.transform.localRotation.eulerAngles.y;
        towerHP = 100;
        //bullet = Instantiate(Resources.Load("ball", typeof(GameObject))) as GameObject; //Pulling null?

    }

    void GetDamage()
    {
        if(currentTarget)
        {
            currentTarget.GetComponent<enemyHealth>().Damage(damageAmount);
        }
    }

    
    void Update()
    {
        //Look at target
        if(currentTarget)
        {
            Vector3 direction = currentTarget.transform.position - cannonPivot.transform.position;
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);
            cannonPivot.transform.rotation = Quaternion.Slerp(cannonPivot.transform.rotation, rotation, 5 * Time.deltaTime);

            //Trigger section
            if(currentTarget.CompareTag("Dead"))
            {
                locked = false;
                this.currentTarget = null;
            }

        }
        else
        {
            locked = false;
            Quaternion home = new Quaternion (0, cannonRest, 0, 1);
            cannonPivot.transform.rotation = Quaternion.Slerp(cannonPivot.transform.rotation, home, Time.deltaTime);
        }



        //Shooting at target
        if(!shooting)
        {
            StartCoroutine(shoot());
        }

        if(isDead == true)
        {
            if(!currentTarget || currentTarget.CompareTag("Dead"))
            {
                StopCatcherAttack();
            }
        }

        //Tower Destroyed
        if(towerHP <= 0)
        {
            Destroy(gameObject);

        }
        
        IEnumerator shoot()
        {
            shooting = true;
            yield return new WaitForSeconds(shootDelay);

            if(currentTarget && isDead == false)
            {
                GameObject b = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
                b.GetComponent<TowerBullet>().target = currentTarget;
                b.GetComponent<TowerBullet>().twr = this;
            }

            if (currentTarget && isDead == true)
            {
                anim.SetBool("Attack", true);
                anim.SetBool("T_pose", false);
            }

            shooting = false;
        }

        void StopCatcherAttack()
        {
            currentTarget = null;
            anim.SetBool("Attack", false);
            anim.SetBool("T_pose", true);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemyBug") && !locked)
        {
            currentTarget = other.gameObject.transform;
            locked = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("enemyBug") && other.gameObject == currentTarget)
        {
            locked = false;
            currentTarget = null;
        }
    }
}
