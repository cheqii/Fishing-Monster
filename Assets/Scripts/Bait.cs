using UnityEngine;

public class Bait : MonoBehaviour
{
    [Header("Line Renderer")]
    private LineRenderer _line;
    [SerializeField] private Transform[] rodPoints;

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
            MakeRodline();
            if(Input.GetMouseButtonDown(1)) Destroy(this.gameObject);
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
