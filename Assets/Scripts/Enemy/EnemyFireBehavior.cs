using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBehavior : MonoBehaviour
{
    [SerializeField]
    private float misfire;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireAtEnemy", 5, 5);
    }

    private void FireAtEnemy()
    {
        Vector3 inaccurate = new Vector3(Random.Range(-misfire, misfire), Random.Range(-misfire, misfire), 0);
        gameObject.GetComponent<Fire>().FireBullet(gameObject.transform.position, GameObject.Find("Player").transform.position + inaccurate, 2);
    }
}
