using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishRadar : MonoBehaviour
{

    [SerializeField] private Fish _fish;
    [SerializeField] private Vector3 offset;
    private FishData _fishData;
    private GameObject _bait;
    private bool isEating = false;
    private bool isDissolve = false;
    private RealBait bait;


    [SerializeField] private Vector3 biteOffset;
    private CoinBomb coinBomb;

    private void Start()
    {
        coinBomb = GetComponentInParent<CoinBomb>();
        _fish = this.transform.parent.gameObject.GetComponent<Fish>();
        _fishData = _fish.GetFishData();
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (_fishData._FishType == null) return;
        
        //predator
        if(_fishData._FishType == FishData.FishType.Predator)
        {
            if (col.name != "Rod") return;
            
            transform.parent.GetComponent<Fish>().enabled = false;
            
            //set cecnter

            transform.parent.transform.position =
                Vector3.Lerp(transform.parent.transform.position , col.transform.position - biteOffset, Time.deltaTime * 0.5f);
            
            
            
            
            return;
        }
        
        
        //normal
        bait = col.gameObject.GetComponent<RealBait>();
        if (bait != null && bait.isEaten == false && bait.Cancel == false)
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
        isEating = true;
        bait.isEaten = true;
        GameManager.Instance.fishIsEating = true;

        _bait = bait.gameObject;
        
        bait.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GameObject fish = this.gameObject.transform.parent.gameObject;
        fish.GetComponent<Fish>().enabled = false;

        bait.GetComponent<ShakyObject>().enabled = true;
        
        StartCoroutine(EatBait(fish.transform, bait.transform, _fish));
        
        
        //blood
        var blood = Instantiate(GameManager.Instance.blood, _fish.getCenter(),Quaternion.identity);
        blood.transform.SetParent(_fish.transform);
        blood.transform.localScale = _fish.transform.localScale * 2;
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
    }


    IEnumerator EatBait(Transform t1, Transform t2, Fish _fish)
    {
        GameManager.Instance.currentFish = transform.parent.GetComponent<Fish>();
        
        
        while (true)
        {
            if (GameManager.Instance.fishIsEating == false && _fish.isDead == false )
            {
                _fish.GetComponent<Fish>().enabled = true;
                if (bait != null)
                {
                    bait.baitSprite.sprite = null;

                }
                break;
            }


            if (isEating == true && t2 == null && _fish.isDead == true && isDissolve == false)
            {
                LerpTransform(_fish.transform,FindObjectOfType<Rod>().transform,Time.deltaTime);
                
                if (_fish.isHitBoat == true)
                {
                    StartCoroutine(fishDissolve(_fish));
                }
            }

            if (t1 != null && t2 != null)
            {
                var start = t1.transform.localPosition;

                Vector3 gap = (_fish.getCenter() - t1.position) - new Vector3(t1.localScale.x,0,0);
                
                var target = t2.transform.localPosition - gap + offset;
                t1.transform.localPosition =  Vector3.Lerp(start, target,1);
            }
            yield return new WaitForSeconds(Time.deltaTime);

        }

    }


    IEnumerator fishDissolve(Fish _fish)
    {            
        float transition = 0;
        isDissolve = true;



        while (true)
        {
            
            transition += Time.deltaTime * 2;
            _fish.newMat.SetFloat("_Transition", transition);
            yield return new WaitForSeconds(Time.deltaTime);

            if (transition > 1)
            {
                var blood = _fish.GetComponentInChildren<ParticleSystem>();
                blood.transform.SetParent(null);
                blood.loop = false;
                GameManager.Instance.DestroyGO(blood.gameObject, 10);
                
                Destroy(_fish.gameObject);
                
                // After fish have destroy the coin particle system will exploded
                Debug.Log("fish hooked");
                
                int coinCollect = Random.Range(_fishData.minCoinDrop, _fishData.maxCoinDrop);
                coinBomb.DropCoins(coinCollect);
            }
        }
     
    }
}
