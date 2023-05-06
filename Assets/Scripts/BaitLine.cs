using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitLine : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineController line;

    // private void Start()
    // {
    //     line.SetupLine(points);
    // }

    // private void Update()
    // {
    //     line.SetupLine(points);
    // }

    public void DrawLine()
    {
        line.SetupLine(points);
    }
}
