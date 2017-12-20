using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

	Vector3 rotaPoint;
	// Use this for initialization
	void Start () {

		rotaPoint = new Vector3 (-28f, 6.4f, 0f);

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround (rotaPoint, Vector3.up, 1f * Time.deltaTime);
	}
}
