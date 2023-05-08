using System;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        var fish = other.GetComponentInParent<Fish>();
        
        if (other.CompareTag("Radar"))
            Destroy(fish.gameObject);
    }
}
