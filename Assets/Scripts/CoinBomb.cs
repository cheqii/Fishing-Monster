using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
public class CoinBomb : MonoBehaviour
{
    [SerializeField] private int resourceCount;
    [SerializeField] private GameObject resourceNode;

    private ParticleSystem pfx;
    private int amountCoin = 0;
    private void Start()
    {
        pfx = GetComponentInParent<ParticleSystem>();
    }

    public void DropCoins(int value)
    {
        int amountToSpawn = Mathf.Min(value, resourceCount - amountCoin);
        if (amountToSpawn > 0)
        {
            pfx.Emit(value);
            amountCoin += amountToSpawn;
        }

        if (amountCoin >= resourceCount)
        {
            Destroy(gameObject);
        }
    }
}
