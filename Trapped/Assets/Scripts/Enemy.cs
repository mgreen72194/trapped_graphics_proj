using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    private int currPoint; // Controls where the enemy is walking towards

    // Use this for initialization
    void Start()
    {
        currPoint = 0;
        transform.position = patrolPoints[1].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == patrolPoints[currPoint].position)
            currPoint += 1;

        if (currPoint >= patrolPoints.Length) // Move enemy to the original point, starting all over again
            currPoint = 0;

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currPoint].position, moveSpeed * Time.deltaTime);
    }
}

