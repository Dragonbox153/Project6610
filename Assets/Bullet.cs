using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 moveDirection;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float travelTime;
    private float timeTravelled;
    private GameObject startPoint;

    void Awake()
    {
        timeTravelled = 0;
    }

    void Update()
    {
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
}
