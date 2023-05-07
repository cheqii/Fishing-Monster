using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform throwingPoint;
    [SerializeField] private Rigidbody2D gameObjRb;

    [SerializeField] private bool isFishing = false;

    private Rigidbody2D[] baitGameObjects = new Rigidbody2D[2];

    public bool IsFishing
    {
        get => isFishing;
        set => isFishing = value;
    }
    
    private void Update()
    {
        if(!isFishing) ClickBait();


        if (Input.GetMouseButtonDown(1) && baitGameObjects[0].GetComponent<Bait>().GetIsInWater() == true)
        {
            Vector2 projectileVelocity = CalculateProjectile(baitGameObjects[0].transform.position, transform.position, 1f);
            baitGameObjects[0].velocity = projectileVelocity;
            FindObjectOfType<RealBait>().Cancel = true;
            //baitGameObjects[0] = null;
        }
    }
    
    public void ClickBait()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                Vector2 projectileVelocity = CalculateProjectile(throwingPoint.position, hit.point, 1f);
                Rigidbody2D baitFishing = Instantiate(gameObjRb, throwingPoint.position, Quaternion.identity);
                baitFishing.velocity = projectileVelocity;
                baitGameObjects[0] = baitFishing;
                baitFishing.GetComponent<Bait>().rodPoints[0] = this.transform;
                IsFishing = true;


                StartCoroutine(delayCollider());
            }
        }

       
        
    }


    IEnumerator delayCollider()
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
