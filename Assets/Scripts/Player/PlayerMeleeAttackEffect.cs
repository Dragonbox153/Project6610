using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyHealth>()  != null)
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(2);
        }
    }
}
