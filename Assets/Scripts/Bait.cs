using System.Collections;
using UnityEngine;

public class Bait : MonoBehaviour
{
    [Header("Line Renderer")]
    private LineRenderer _line;
    public Transform[] rodPoints;
    private Rod _rod;
    private bool createLine = false;
    [SerializeField] private bool isInWater;

    [SerializeField] private GameObject RealBait;
    [SerializeField] private GameObject realBaitGameObject;

    private bool isRealBaitYet = false;

    [SerializeField] private BaitData baitData;
    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        _rod = FindObjectOfType<Rod>().GetComponent<Rod>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.CompareTag("Water"))
        {
            isInWater = true;
            
            Debug.Log("Bait triggered water");
            GetComponent<TrailRenderer>().enabled = false;
            createLine = true;

            if (isRealBaitYet == false)
            {
                var _realBait = Instantiate(RealBait, transform.position, Quaternion.identity);
                _realBait.GetComponent<RealBait>().SetBait(this.baitData);
                realBaitGameObject = _realBait;
                _realBait.GetComponent<RealBait>().buoyancy = this.transform;
                _realBait.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
                StartCoroutine(setRealBait(_realBait.GetComponent<LineRenderer>()));
                isRealBaitYet = true;
            }
            
        }

        if (col.CompareTag("Boat"))
        {
            var projectiles = col.GetComponent<Rod>();
            if (projectiles != null || isInWater == false)
            {
                if(realBaitGameObject != null) realBaitGameObject.GetComponent<RealBait>().enabled = false;

                
                _rod.DeleteBait();
                
                Destroy(realBaitGameObject);
                Destroy(this.gameObject);
            }
        }
    }
    
    
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Water"))
        {
            isInWater = true;

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        isInWater = false;
    }

    private void FixedUpdate()
    {
        if (createLine)
        {
            MakeRodline();
        }
    }

    private void MakeRodline()
    {
        if (BoatDisappear()) return;
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

    IEnumerator setRealBait(LineRenderer _lineRenderer)
    {
        while (true)
        {
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1,_lineRenderer.transform.position );
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void SetBait(BaitData _data)
    {
        this.baitData = _data;
    }
    
    private bool BoatDisappear()
    {
        if (rodPoints[0] != null) return false;
        
        _rod.DeleteBait();
        Destroy(realBaitGameObject);
        Destroy(this.gameObject);
        return true;
    }
}
