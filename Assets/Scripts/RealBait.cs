using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealBait : MonoBehaviour
{
    public Transform buoyancy;

    public bool Cancel= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cancel == true)
        {
            transform.position = Vector3.Lerp(transform.position, buoyancy.position, Time.deltaTime*10);
        }
    }
}
