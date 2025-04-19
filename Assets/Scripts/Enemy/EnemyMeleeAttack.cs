using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] GameObject enemyMeleeAttack;
    GameObject player;
    GameObject currEnemyAttack;
    bool attacking = false;
    float attackDuration = 1;
    float attackTime = 1;
    float attackDelay = 2;
    float delayTime = 2;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void MeleeAttack()
    {
        delayTime -= Time.deltaTime;

        if (delayTime <= 0 && !attacking && player != null && Vector2.Distance(this.transform.position, player.transform.position) < 2)
        {
            delayTime = attackDelay;
            attackTime = attackDuration;
            attacking = true;
            Quaternion quaternion = Quaternion.Euler(0, 0, Mathf.Atan2(transform.position.y - player.transform.position.y, transform.position.x - player.transform.position.x) * Mathf.Rad2Deg - 90);
            currEnemyAttack = Instantiate(enemyMeleeAttack, transform.position, quaternion);
            currEnemyAttack.GetComponent<EnemyAttackEffect>().enemy = this.gameObject;
        }

        if (attacking)
        {
            attackTime -= Time.deltaTime;
        }

        if (attackTime <= 0)
        {
            attacking = false;
            Destroy(currEnemyAttack);
        }
    }

    private void OnDestroy()
    {
        Destroy(currEnemyAttack);
    }
}
