using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEffect : MonoBehaviour
{
    GameObject enemy;

    private void Awake()
    {
        enemy = this.gameObject;
    }

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
