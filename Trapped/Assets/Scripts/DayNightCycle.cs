using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.RotateAround(Vector3.zero, Vector3.right, 7f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
	}
}
