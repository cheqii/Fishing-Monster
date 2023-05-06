using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Bait : MonoBehaviour
{
    private Transform baitTransform;
    public Transform BaitTransform
    {
        get => baitTransform;
        set => baitTransform = value;
    }

    private LineRenderer _line;
    [SerializeField] private Transform[] points;
    
    

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Water"))
        {
            Debug.Log("Bait triggered water");
            GetComponent<TrailRenderer>().enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            Makeline();
        }
    }

    private void Makeline()
    {
        Transform begin = points[0];
        Transform end = points[1];
        _line.positionCount = points.Length;
        _line.SetPosition(0, begin.position);
        _line.SetPosition(1, end.position);
    }
}
