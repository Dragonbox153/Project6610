using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEffect : MonoBehaviour
{
    public GameObject enemy;

    private void FixedUpdate()
    {
        if(enemy != null)
        {
            this.transform.position = enemy.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerHealth>()  != null)
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(2);
        }
    }
}
