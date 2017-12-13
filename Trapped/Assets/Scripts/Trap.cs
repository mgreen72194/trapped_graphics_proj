using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Protrude ());
	}
	
	IEnumerator Protrude()
    {
        while(true)
        {
            gameObject.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(3f);
        }
    }
}
