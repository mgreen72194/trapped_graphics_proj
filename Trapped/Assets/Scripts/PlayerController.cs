using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float maxSpeed = 6f; // Make sure the ball doesn't exceed max speed
    private Rigidbody rb;
    private Vector3 input; // Keyboard Input
    private Vector3 checkPoint; // After player is destroyed, it will be brought back to this point
    private bool onGround; // Check whether the player is on ground
    public bool onPlate; // Check whether the player is on the moving plate
    public GameObject deathEffect; // The special effect when the player is destroyed
    public GameObject human;
    private int count; // Count how many objects have been collected
    public int total; // Total number of collectible objects we have
    public Text score;
    public Text endGameText;

    // Use this for initialization
    void Start()
    {
        int count = 0;
        rb = GetComponent<Rigidbody>();
        checkPoint = transform.position;
        onGround = true;
        onPlate = false;
        if(score != null)
            score.text = "Collectible: " + count.ToString() + " out of " + total;
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

        if (transform.position.y < -7 && !onPlate) // Bring player back to check point if failing off the stage
            transform.position = checkPoint;

        if (onPlate && transform.position.y < -23) // Make sure player will be destoryed after getting on the plate
            transform.position = checkPoint;

        if (Input.GetKey("escape")) // Exit the game in the full screen mode
            Application.Quit();
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

        if (other.transform.tag == "MovingPlatform")
            onPlate = true ;

		if (other.transform.tag == "EndGame") {
            gameObject.SetActive(false);
            Instantiate(human, new Vector3(transform.position.x, transform.position.y, transform.position.z-5), Quaternion.identity);
            endGameText.text = "Congratulation! You are free from your entrapment.";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Collectible")
        {
            other.gameObject.SetActive(false);
            count += 1;
            score.text = "Collectible: " + count.ToString() + " out of " + total;
        }
    }

}
