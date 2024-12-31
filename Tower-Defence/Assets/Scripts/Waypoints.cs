using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;   // Arrays with waypoints
    void Awake()
    {
        points = new Transform[transform.childCount];   // Counts the number of waypoints
        for (int i = 0; i < points.Length; i++) 
        {
            points[i] = transform.GetChild(i); // adds the waypoints to the variable
        }
    }
}
