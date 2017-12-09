using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float maxSpeed = 5f;
    private Rigidbody rb;
    private Vector3 input;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
}
