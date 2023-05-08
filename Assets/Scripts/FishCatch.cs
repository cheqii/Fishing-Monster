using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCatch : MonoBehaviour
{
    [SerializeField] private bool isStayOnFish;
 
    

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("FishUi"))
        {
            isStayOnFish = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("FishUi"))
        {

            FindObjectOfType<FisherManAnime>().Fighting(1);


        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("FishUi"))
        {
            isStayOnFish = false;
            FindObjectOfType<FisherManAnime>().Idle(1);

        }
    }

    public bool GetStayOn()
    {
        return isStayOnFish;
    }
}
