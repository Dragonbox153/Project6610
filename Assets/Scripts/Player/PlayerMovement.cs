using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 velocity;
    Vector2 acceleration;
    [SerializeField] float maxVelocity;
    [SerializeField] float speed;
    public Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(0, 0);
        acceleration = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Get acceleration from keyboard
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        acceleration = new Vector2(moveX, moveY).normalized;

        acceleration *= speed;
    }

    private void FixedUpdate()
    {
        // Apply drag
        // The last variable in the Lerp is not time, it's by how much to change velocity by each time it's called
        velocity = Vector2.Lerp(velocity, acceleration * maxVelocity, 0.1f);
        if (velocity.magnitude > maxVelocity) { 
            velocity *= maxVelocity / velocity.magnitude;
        }

        // Move Player
        player.MovePosition((Vector2)transform.position + (velocity * Time.deltaTime));
    }
}
