using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Transform patrolPoint;
    public float moveSpeed;
    private bool onPlate; // Check whether the player is on the moving plate

    // Use this for initialization
    void Start()
    {
        onPlate = false;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(onPlate)
            transform.position = Vector3.MoveTowards(transform.position, patrolPoint.position, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
            onPlate = true;
    }
}
