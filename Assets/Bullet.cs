using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float travelTime;
    private float timeTravelled;
    private GameObject startPoint;
    private byte bulIDStart;
    private byte bulID;

    void Awake()
    {
        timeTravelled = 0;
        bulID = bulIDStart;
    }

    void Update()
    {
        bulID = bulIDStart;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        timeTravelled += Time.deltaTime;
        if(timeTravelled >= travelTime)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        timeTravelled = 0;
        gameObject.SetActive(false);
    }

    public void SetMoveDirection(Vector2 newDir)
    {
        moveDirection = newDir;
    }

    public void SetBulletID(byte ID)
    {
        bulIDStart = ID;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bulID = bulIDStart;
        if(timeTravelled > 0)
        {
            if(collision.GetComponent<EnemyHealth>()  != null && bulletIsType(1))
            {
                collision.GetComponent<EnemyHealth>().TakeDamage(2);
                Destroy();
            }
            if(collision.GetComponent<PlayerHealth>()  != null && bulletIsType(2))
            {
                collision.GetComponent<PlayerHealth>().TakeDamage(2);
                Destroy();
            }
        }
    }

    private bool bulletIsType(byte type)
    {
        Debug.Log(bulID);
        return bulID == 0 || bulID == type;
    }
}
