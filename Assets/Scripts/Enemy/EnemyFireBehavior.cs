using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBehavior : MonoBehaviour
{
    public void FireAtEnemy()
    {
        this.StartCoroutine(FireCoroutine(5));
    }
    public IEnumerator FireCoroutine(float misfire)
    {
        Vector3 inaccurate = new Vector3(Random.Range(-misfire, misfire), Random.Range(-misfire, misfire), 0);
        gameObject.GetComponent<Fire>().FireBullet(gameObject.transform.position, GameObject.Find("Player").transform.position + inaccurate, 2);
        yield return new WaitForSeconds(0.5f);
    }
}
