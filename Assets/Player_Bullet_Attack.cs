using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player_Bullet_Attack : MonoBehaviour
{
    bool attacking = false;
    [SerializeField]
    float attackDuration = 1;
    float attackTime = -1;

    private void Update()
    {
        if (!attacking && Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Fire>().FireBullet(gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
        }

        if (attacking)
        {
            attackTime -= Time.deltaTime;
        }

        if (attackTime <= 0)
        {
            attacking = false;
            attackTime = attackDuration;
        }
    }
}
