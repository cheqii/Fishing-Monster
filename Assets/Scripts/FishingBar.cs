using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingBar : MonoBehaviour
{
    [SerializeField] private FishCatch _fishCatch;
    [SerializeField]  private float progressSpeed = 20;

    [SerializeField] private Slider progressBar;
    [SerializeField] private Slider elctricBar;
    [SerializeField] private ParticleSystem _particle;
    
    [Range(0,5)]
    [SerializeField] private float elctricBarRecoveryRate;
    
    [Range(-1,1)]
    [SerializeField] private float elctricResistance;




        
        
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_fishCatch.GetStayOn() == true)
        {
            progressBar.value += (Time.deltaTime/100)*progressSpeed ;
            
            //fish shock
            if (Input.GetKeyDown(KeyCode.V))
            {
                elctricBar.value -= 1;
                progressBar.value += progressBar.maxValue / 100 * elctricResistance;
                _particle.Play();

            }
        }
        else
        {
            progressBar.value -= (Time.deltaTime/100)*progressSpeed/2;
            
            //fish shock
            if (Input.GetKeyDown(KeyCode.V))
            {
                progressBar.value -= progressBar.maxValue / 100;
            }
        }
        
        elctricBar.value += (Time.deltaTime * elctricBarRecoveryRate);

        
        
    }
}
