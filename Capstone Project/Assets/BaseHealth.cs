using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseHealth : MonoBehaviour
{
    public int Health = 100;
    public HealthBar healthbar;

    void Start()
    {
        healthbar.SetMaxHealth(Health);
    }

    public void Damage(int dmg)
    {
        Health -= dmg;

        healthbar.SetHealth(Health);
    }

    private void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject, 1f);
            SceneManager.LoadScene("Game Over");
        }
    }
}
