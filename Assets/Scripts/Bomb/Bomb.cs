using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bomb : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        var fish = col.gameObject.GetComponent<Fish>();
        if (col.CompareTag("Fish") && fish._fishData._FishType == FishData.FishType.Normal) return;
        if (col.CompareTag("Fish") && fish._fishData._FishType == FishData.FishType.Predator)
        {
            transform.Find("Explosion").GetComponent<Explosion>().ExplosionReady();
            int coin = Random.Range(fish._fishData.minCoinDrop, fish._fishData.maxCoinDrop);
            
            col.GetComponentInChildren<CoinBomb>().DropCoins(coin);
        }
    }
}
