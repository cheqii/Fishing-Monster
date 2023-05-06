using UnityEngine;

public class FishingProjectile : MonoBehaviour
{
    [SerializeField] private Transform fishingPoint;
    public Transform FishingPoint => fishingPoint;
    [SerializeField] private Rigidbody2D baitRb;

    private void Update()
    {
        ClickBait();
    }
    
    void ClickBait()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                Vector2 projectileVelocity = CalculateProjectile(fishingPoint.position, hit.point, 1f);
                Rigidbody2D baitFishing = Instantiate(baitRb, fishingPoint.position, Quaternion.identity);
                
                baitFishing.velocity = projectileVelocity;
            }
        }
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
