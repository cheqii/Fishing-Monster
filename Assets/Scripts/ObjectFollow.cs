using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public Transform target;
    
 
    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null) return;
        transform.localPosition = Vector3.Lerp(this.transform.position, target.position, 1);
    }
}
