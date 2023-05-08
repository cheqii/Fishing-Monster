using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Radar") == true)
        {
            Debug.Log(col.name);

            transform.Find("Explosion").GetComponent<Explosion>().ExplosionReady();
        }
        
    }

    
  
}
