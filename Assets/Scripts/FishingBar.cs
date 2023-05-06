using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingBar : MonoBehaviour
{
    [SerializeField] private FishCatch _fishCatch;
    [SerializeField]  private float progressSpeed = 20;

    private Slider progressBar;

        
        
    // Start is called before the first frame update
    void Start()
    {
        progressBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_fishCatch.GetStayOn() == true)
        {
            progressBar.value += (Time.deltaTime/100)*progressSpeed ;
        }
        else
        {
            progressBar.value -= (Time.deltaTime/100)*progressSpeed/2;
        }
    }
}
