using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    private bool onPlatform;
    Vector3 original; // The original position of the platform

    // Use this for initialization
    void Start () {
        original = transform.position;
        onPlatform = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 velocity = new Vector3(0, 2.0f*Time.deltaTime, 0);

        if (onPlatform)
            transform.position -= velocity;

        if (transform.position.y < -6)
        {
            transform.position = original;
            onPlatform = false;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
            onPlatform = true;
    }
}
