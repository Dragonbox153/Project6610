using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffect : MonoBehaviour
{
    [SerializeField]
    private byte bulID;
    // 0: Any
    // 1: Player
    // 2: Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyHealth>()  != null && bulletIsType(1))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(2);
        }
        if(collision.GetComponent<PlayerHealth>()  != null && bulletIsType(2))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(2);
        }
    }

    private bool bulletIsType(byte type)
    {
        return bulID == 0 || bulID == type;
    }
}
