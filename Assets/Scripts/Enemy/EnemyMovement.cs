using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector2 velocity;
    public Vector2 acceleration;
    public float maxVelocity;
    public float speed;
    public Rigidbody2D enemy;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(0, 0);
        acceleration = new Vector2(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = Vector2.Lerp(velocity, acceleration * maxVelocity, 1f);
        if (velocity.magnitude > maxVelocity)
        {
            velocity *= maxVelocity / velocity.magnitude;
        }

        enemy.MovePosition((Vector2)transform.position + (velocity * Time.deltaTime));
    }
}
