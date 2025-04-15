using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerHealth>()  != null)
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(2);
        }
    }
}
