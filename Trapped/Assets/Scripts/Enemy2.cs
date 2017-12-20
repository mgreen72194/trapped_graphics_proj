using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject player;
    public Transform standingPoint;
    public float moveSpeed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        transform.position = standingPoint.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.transform.position, standingPoint.position);

        if(distance<7)
        {
			Vector3 lookDir = Vector3.RotateTowards (transform.position, player.transform.position, 10f, 10f);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

			transform.rotation = Quaternion.LookRotation (lookDir);
        }

    }
}