using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        byte bulID = gameObject.GetComponent<Bullet>().GetBulletID();
        if(collision.GetComponent<EnemyHealth>()  != null && bulletIsType(bulID, 1))
        {
            Debug.Log("Player lands a close hit!");
            collision.GetComponent<EnemyHealth>().TakeDamage(2);
        }
        if(collision.GetComponent<PlayerHealth>()  != null && bulletIsType(bulID, 2))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(2);
        }
    }

    private bool bulletIsType(byte bulID, byte type)
    {
        return bulID == 0 || bulID == type;
    }
}
