using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] GameObject meleeAttack;
    GameObject attack;
    bool attacking = false;
    float attackDuration = 1;
    float attackTime = 1;

    private void Update()
    {
        if (!attacking && Input.GetMouseButtonDown(0))
        {
            attackTime = attackDuration;
            attacking = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Quaternion quaternion = Quaternion.Euler(0, 0, Mathf.Atan2(transform.position.y - mousePos.y, transform.position.x - mousePos.x) * Mathf.Rad2Deg - 90);
            attack = Instantiate(meleeAttack, transform.position, quaternion);
        }

        if (attacking)
        {
            attackTime -= Time.deltaTime;
        }

        if(attackTime <= 0)
        {
            attacking = false;
            Destroy(attack.gameObject);
        }
    }
}
