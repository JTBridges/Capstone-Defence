using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int Health = 30;
    public int MinionDamage = 10;
    public float SetAttackSpeed = 1;
    private float AttackTime = 1;
    public bool Attacking = false;
    private Animator anim;
    private const float moveSpeed = .02f;
    public GameObject thePlayer;
    public GameObject resourceObject;
    public GameObject manager;
    public HealthBar healthBar;

    void Start()
    {
        anim = transform.GetComponent<Animator>();
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        resourceObject = GameObject.FindGameObjectWithTag("resourceTarget");
        manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<waveSystem>().incrementSpawn();
        healthBar.SetMaxHealth(Health);
    }

    public void Damage(int dmg)
    {
        Health -= dmg;

        healthBar.SetHealth(Health);
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
        AttackTime -= Time.deltaTime;
        if(AttackTime <= 0 && Attacking == true && Health > 0)
        {
            thePlayer.GetComponent<BaseHealth>().Damage(MinionDamage);
            AttackTime = SetAttackSpeed;
        }
 //       anim.SetBool("getHit", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Attacking = true;
        }
        if(other.CompareTag("DamageSpell"))
        {
            Damage(10);
        }
    }
    private void FixedUpdate()
    {
        resourceObject = GameObject.FindGameObjectWithTag("resourceTarget");
    }
    private void OnDestroy()
    {
        Attacking = false;
        resourceObject.GetComponent<resourceGather>().incrementMonsterKill();
        manager.GetComponent<waveSystem>().removeEnemyAmount();
        manager.GetComponent<waveSystem>().decrementSpawn();
    }

    
}
