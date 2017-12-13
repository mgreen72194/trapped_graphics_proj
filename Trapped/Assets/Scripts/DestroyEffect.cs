using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour {
    public float lifespan = 2f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifespan);
	}
}
