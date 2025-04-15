using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public int maxHealth = 5;

    public void TakeDamage(int i_damage)
    {
        health -= i_damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int i_heal)
    {
        if (health + i_heal <= maxHealth)
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
        if (health < maxHealth)
        {
            health = i_health;
            maxHealth = i_maxHealth;
        }
    }
}
