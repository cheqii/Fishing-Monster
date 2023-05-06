using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer linerend;
    private Transform[] points;

    private void Awake()
    {
        linerend = GetComponent<LineRenderer>();
    }

    public void SetupLine(Transform[] points)
    {
        linerend.positionCount = points.Length;
        this.points = points;
    }

    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            linerend.SetPosition(i, points[i].position);
        }
    }
}
