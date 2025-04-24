using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public bool isDamaged;
    private float damageTime = 0;

    public void TakeDamage(int i_damage)
    {
        health -= i_damage;

        isDamaged = true;
        damageTime = 0.75f;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        damageTime -= Time.deltaTime;
        if(damageTime < 0)
        {
            isDamaged = false;
        }
        else
        {
            isDamaged = true;
        }
    }

    public void Heal(int i_heal)
    {
        if(health + i_heal <= maxHealth)
        {
            health += i_heal;
        }
        else
        {
            health = maxHealth;
        }
    }

    public void SetHealth(int i_health, int i_maxHealth)
    {
        if(health < maxHealth)
        {
            health = i_health;
            maxHealth = i_maxHealth;
        }
    }
}
