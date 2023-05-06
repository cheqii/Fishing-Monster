using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCatch : MonoBehaviour
{
    [SerializeField] private bool isStayOnFish;
    
 
    

    private void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.CompareTag("FishUi"))
        {
            isStayOnFish = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("FishUi"))
        {
            isStayOnFish = false;
        }
    }

    public bool GetStayOn()
    {
        return isStayOnFish;
    }
}
