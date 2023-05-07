using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRadar : MonoBehaviour
{

    [SerializeField] private Vector3 offset;
    private void OnTriggerEnter2D(Collider2D col)
    {
        var bait = col.gameObject.GetComponent<RealBait>();
        if (bait != null)
        {
            bait.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject fish = this.gameObject.transform.parent.gameObject;
            fish.GetComponent<Fish>().enabled = false;
            StartCoroutine(EatBait(fish.transform, bait.transform));
        }
    }
    

    public static void LerpTransform (Transform t1, Transform t2, float t)
    {
        t1.position =   Vector3.Lerp(t1.position, t2.position, t);
        //t1.rotation =   Quaternion.Lerp (t1.rotation, t2.rotation, t);
        //t1.localScale =   Vector3.Lerp(t1.localScale, t2.localScale , t);
    }


    IEnumerator EatBait(Transform t1, Transform t2)
    {
        
        while (true)
        {
            var start = t1.transform.localPosition;
            var target = t2.transform.localPosition + offset;
            t1.transform.localPosition =  Vector3.Lerp(start, target,Time.deltaTime*3);
            yield return new WaitForSeconds(Time.deltaTime);
        }

    }
}
