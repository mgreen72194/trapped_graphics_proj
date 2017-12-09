using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float maxSpeed = 5f; // Make sure the ball doesn't exceed max speed
    private Rigidbody rb;
    private Vector3 input; // Keyboard Input
    private Vector3 checkPoint; // After player is destroyed, it will be brought back to this point

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        checkPoint = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.AddForce(input * moveSpeed);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            transform.position = checkPoint;
        }
    }
}
