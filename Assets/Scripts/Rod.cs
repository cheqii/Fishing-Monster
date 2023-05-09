using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Rod : MonoBehaviour
{
    public Transform throwingPoint;
    
    [Header("Fishing point")]
    [SerializeField] private Rigidbody2D fishingBaitPoint;

    public Rigidbody2D FishingBaitPoint
    {
        get => fishingBaitPoint;
        set => fishingBaitPoint = value;
    }
    
    [Header("Bomb point")]
    [SerializeField] private Rigidbody2D bombPoint;

    [SerializeField] private bool isFishing = false;
    [SerializeField] private BaitData baitData;
    public BaitData BaitData
    {
        get => baitData;
        set => baitData = value;
    }

    private Rigidbody2D[] baitGameObjects = new Rigidbody2D[2];

    public bool IsFishing
    {
        get => isFishing;
        set => isFishing = value;
    }

    private void Update()
    {
        if (GameManager.Instance.fishIsEating == true) { return;}
        
        if (Input.GetMouseButtonDown(1) && baitGameObjects[0] != null && baitGameObjects[0].GetComponent<Bait>().GetIsInWater() == true)
        {
            Vector2 projectileVelocity = CalculateProjectile(baitGameObjects[0].transform.position, transform.position, 1f);
            baitGameObjects[0].velocity = projectileVelocity;
            FindObjectOfType<RealBait>().Cancel = true;
            
        }
    }
    
    public void ClickBait()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if(hit.collider.gameObject.layer == 5)
            {
                return;
            }
            
            if (hit.collider != null)
            {
                Vector2 projectileVelocity = CalculateProjectile(throwingPoint.position, hit.point, 1f);
                if (SwitchTool.Instance.ToolTypes == Tools.Rod)
                {
                    Rigidbody2D baitFishing = Instantiate(fishingBaitPoint, throwingPoint.position, Quaternion.identity);
                    baitFishing.GetComponent<Bait>().SetBait(this.baitData);
                    baitFishing.velocity = projectileVelocity;
                    baitGameObjects[0] = baitFishing;
                    baitFishing.GetComponent<Bait>().rodPoints[0] = throwingPoint;
                    IsFishing = true;
                    
                    StartCoroutine(DelayCollider());
                }
                else if (SwitchTool.Instance.ToolTypes == Tools.Bomb)
                {
                    FindObjectOfType<FisherManAnime>().Cannon(1);
                    Rigidbody2D bomb = Instantiate(bombPoint, throwingPoint.position, Quaternion.identity);
                    bomb.velocity = projectileVelocity;
                }
            }
    }

    


    IEnumerator DelayCollider()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(2);
        GetComponent<BoxCollider2D>().enabled = true;

    }

    public void DeleteBait()
    {
        baitGameObjects[0] = null;
        isFishing = false;  

    }
    
    
    Vector2 CalculateProjectile(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
        float distanceX = distance.x;
        float distanceY = distance.y;
        
        float velocityX = distanceX / time;
        float velocityY = distanceY / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;
        
        Vector2 result = new Vector2(velocityX, velocityY);

        return result;
    }
}
