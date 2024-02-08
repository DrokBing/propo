using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float initialSize;
    private float initialMass;
    private float initialGravity;
    private float moveSpeed = 0.2f;
    private float jumpForce = 0.1f;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Save initial properties
        initialSize = transform.localScale.x;
        initialMass = GetComponent<Rigidbody2D>().mass;
        initialGravity = Physics.gravity.y;
    }

    void Update()
    {
        // Check for input to adjust ball size, mass, and gravity
        if (Input.GetKeyDown(KeyCode.J))
        {
            IncreaseBallSize();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            DecreaseBallSize();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        isGrounded = IsGrounded();
    }
    bool IsGrounded()
    {
        // Cast a ray downwards to check if the ball is grounded
        return Physics2D.Raycast(transform.position, Vector2.down, 0.01f);
    }
    void IncreaseBallSize()
    {
        transform.localScale *= 1.2f;

        GetComponent<Rigidbody2D>().mass *= 0.8f;

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y - 1.2f, Physics.gravity.z);
        Debug.Log(Physics.gravity);
    }

    void DecreaseBallSize()
    {
        if (transform.localScale.x > initialSize * 0.2f)
        {
            // Decrease size
            transform.localScale *= 0.8f;

            // Increase mass
            GetComponent<Rigidbody2D>().mass *= 1.2f;

            // Increase gravity
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y + 1.2f, Physics.gravity.z);
            Debug.Log(Physics.gravity);
        }
    }

    void MoveLeft()
    {
        //transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * moveSpeed);
    }

    void MoveRight()
    {
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * moveSpeed);

    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}


