using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishRadar : MonoBehaviour
{

    [SerializeField] private Fish _fish;
    [SerializeField] private Vector3 offset;
    private FishData _fishData;
    private GameObject _bait;

    private void Start()
    {

        _fish = this.transform.parent.gameObject.GetComponent<Fish>();
        _fishData = _fish.GetFishData();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        var bait = col.gameObject.GetComponent<RealBait>();
        if (bait != null && bait.isEaten == false)
        {
            int randomNum = Random.Range(1, 100);

            switch (bait.GetBait())
            {
                case BaitTypes.Worm:
                    if (randomNum < _fishData.worm)
                    {
                        EatBait(bait);
                    }
                    else
                    {
                        //double speed when not eat
                        _fish.fishExtraSpeed = 4;
                    }
                    break;
                
                case BaitTypes.Shrimp:
                    if (randomNum < _fishData.shrip)
                    {
                        EatBait(bait);
                    }
                    else
                    {
                        //double speed when not eat
                        _fish.fishExtraSpeed = 4;
                    }
                    break;
                
                case BaitTypes.Octopus:
                    if (randomNum < _fishData.octopus)
                    {
                        EatBait(bait);
                    }
                    else
                    {
                        //double speed when not eat
                        _fish.fishExtraSpeed = 4;
                    }   
                    break;
            }
           
           
        }
    }

    void EatBait(RealBait bait)
    {
        bait.isEaten = true;
        GameManager.Instance.fishIsEating = true;

        _bait = bait.gameObject;
        
        bait.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GameObject fish = this.gameObject.transform.parent.gameObject;
        fish.GetComponent<Fish>().enabled = false;

        bait.GetComponent<ShakyObject>().enabled = true;
        
        StartCoroutine(EatBait(fish.transform, bait.transform));
    }

    private void Update()
    {
        if (GameManager.Instance.fishIsEating == false && _bait != null)
        {
            _bait.GetComponent<ShakyObject>().enabled = false;
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
            t1.transform.localPosition =  Vector3.Lerp(start, target,1);
            yield return new WaitForSeconds(Time.deltaTime);
        }

    }
}
