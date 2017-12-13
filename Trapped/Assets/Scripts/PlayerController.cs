using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float maxSpeed = 6f; // Make sure the ball doesn't exceed max speed
    private Rigidbody rb;
    private Vector3 input; // Keyboard Input
    private Vector3 checkPoint; // After player is destroyed, it will be brought back to this point
    private bool onGround; // Check whether the player is on ground
    public GameObject deathEffect; // The special effect when the player is destroyed

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        checkPoint = transform.position;
        onGround = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // Get arrow key inputs

        if (rb.velocity.magnitude <= maxSpeed)
            rb.AddForce(input * moveSpeed); // Add force to the player sphere

        if (onGround & Input.GetKeyDown("space")) // Jump by pressing space
        {
            rb.velocity = new Vector3(0, 7f, 0);
            onGround = false;
        }

        if (transform.position.y < -2) // Bring player back to check point if failing off the stage
            transform.position = checkPoint;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "CheckPoint")
        {
            checkPoint = other.transform.position;
            other.gameObject.SetActive(false); // Makes the check point disappear after player touches it
        }

        if (other.transform.tag == "Enemy")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            transform.position = checkPoint;
        }

        if (other.transform.tag == "Ground")
            onGround = true;

        if (other.transform.tag == "Portal")
            GameManager.NextLevel();
    }

}
