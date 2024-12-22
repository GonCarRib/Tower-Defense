using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    //public Transform enemy;

    public Transform[] wayPoints;
    public float speed;

    public int vida = 100;

    int currentWaypoint = 0;
    float currentDisplacement = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0) {
            Destroy(this);
        }
        Move(currentDisplacement += speed * Time.deltaTime);
    }

    void Move(float displacement)
    {
        if (currentWaypoint < wayPoints.Length - 1)
        {

            
            transform.position = wayPoints[currentWaypoint].position + currentDisplacement * (wayPoints[currentWaypoint + 1].position - wayPoints[currentWaypoint].position);
            if (currentDisplacement >= 1 && currentWaypoint <= wayPoints.Length)
            {
                currentDisplacement = 0;
                currentWaypoint++;
            }
        }
    }
}