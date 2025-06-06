using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] GameObject enemyMeleeAttack;
    GameObject player;
    GameObject currEnemyAttack;
    float timer = 0;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void MeleeAttack()
    {
        Quaternion quaternion = Quaternion.Euler(0, 0, Mathf.Atan2(transform.position.y - player.transform.position.y, transform.position.x - player.transform.position.x) * Mathf.Rad2Deg - 90);
        currEnemyAttack = Instantiate(enemyMeleeAttack, transform.position, quaternion);
        currEnemyAttack.GetComponent<EnemyAttackEffect>().enemy = this.gameObject;        
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            EndAttack();
            timer = 0;
        }
    }

    public void EndAttack()
    {
        Destroy(currEnemyAttack);
    }

    private void OnDestroy()
    {
        Destroy(currEnemyAttack);
    }
}
