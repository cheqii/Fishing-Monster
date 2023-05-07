using System;
using UnityEngine;

public class Bait : MonoBehaviour
{
    [Header("Line Renderer")]
    private LineRenderer _line;
    [SerializeField] private Transform[] rodPoints;
    private Projectile _projectile;
    
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
            Debug.Log("Bait triggered water");
            GetComponent<TrailRenderer>().enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            MakeRodline();
            if (Input.GetMouseButton(0)) GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.05f, ForceMode2D.Impulse);
            if(Input.GetMouseButtonDown(1))
            {
                Destroy(this.gameObject);
                _projectile.IsFishing = false;
            }
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
}
