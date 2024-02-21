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
        if (col.CompareTag("Fish"))
        {
            transform.Find("Explosion").GetComponent<Explosion>().ExplosionReady();
        }
    }
}
