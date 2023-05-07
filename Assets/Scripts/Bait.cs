using System;
using UnityEngine;

public class Bait : MonoBehaviour
{
    [Header("Line Renderer")]
    private LineRenderer _line;
    public Transform[] rodPoints;
    private Projectile _projectile;
    private bool createLine = false;
    private bool isInWater;
    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        _projectile = FindObjectOfType<Projectile>().GetComponent<Projectile>();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.CompareTag("Water"))
        {
            isInWater = true;
            
            Debug.Log("Bait triggered water");
            GetComponent<TrailRenderer>().enabled = false;
            createLine = true;

            //_projectile.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (col.CompareTag("Boat"))
        {
            Projectile[] projectiles = col.GetComponents<Projectile>();
            if (projectiles != null || isInWater == false)
            {
                _projectile.DeleteBait();
                Debug.Log("hit boat");
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        isInWater = false;
    }

    private void FixedUpdate()
    {
        if (createLine == true)
        {
            MakeRodline();

        }
    }

    private void MakeRodline()
    {
        Transform begin = rodPoints[0];
        Transform end = rodPoints[1];
        _line.positionCount = rodPoints.Length;
        _line.SetPosition(0, begin.position);
        _line.SetPosition(1, end.position);
    }

    public bool GetIsInWater()
    {
        return isInWater;
    }
}
