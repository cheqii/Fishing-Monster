using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingBar : MonoBehaviour
{
    [SerializeField] private FishCatch _fishCatch;
    [SerializeField]  private float progressSpeed = 20;

    [SerializeField] private Slider progressBar;
    [SerializeField] private Slider electricBar;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private ParticleSystem flashParticle;

    
    [Range(0,5)]
    [SerializeField] private float electricBarRecoveryRate;
    
    [Range(-1,1)]
    [SerializeField] private float electricResistance;

    [Range(0,5)]
    [SerializeField] private float electricRecoveryDelay = 1f;
    [SerializeField] private float elctricDelayTimer ;

    [SerializeField] private bool elctricCanRecov = true;

        
        
    // Start is called before the first frame update
    void Start()
    {
        elctricDelayTimer = electricRecoveryDelay;
        progressBar.value = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (progressBar.value == 1)
        {
            progressBar.value = 0.4f;
            Debug.Log("already catch fish");
            GameManager.Instance.fishIsEating = false;
            GameManager.Instance.currentFish.isDead = true;
            
            //fish dead
            var flash = Instantiate(GameManager.Instance.flash,GameManager.Instance.currentFish.getCenter(), Quaternion.identity);
            flash.transform.localScale = new Vector3(

                GameManager.Instance.currentFish.transform.localScale.x * flash.transform.localScale.x,
                GameManager.Instance.currentFish.transform.localScale.y * flash.transform.localScale.y,
                GameManager.Instance.currentFish.transform.localScale.z * flash.transform.localScale.z
            );
            
            GameManager.Instance.DestroyGO(flash,10);
            
            GameManager.Instance.currentFish.GetComponent<Animator>().enabled = false;
        }
        
        if (progressBar.value == 0)
        {
            progressBar.value = 0.4f;

            GameManager.Instance.fishIsEating = false;
        }
        
        
        if (_fishCatch.GetStayOn() == true)
        {
            progressBar.value += (Time.deltaTime/100)*progressSpeed ;
            
            //fish shock
            if (Input.GetKeyDown(KeyCode.V) && electricBar.value > 0)
            {
                electricBar.value -= 1;
                progressBar.value += progressBar.maxValue / 100 * electricResistance;
                elctricDelayTimer = electricRecoveryDelay;

                _particle.Play();
                flashParticle.Play();

            }
        }
        else
        {
            progressBar.value -= (Time.deltaTime/100)*progressSpeed/2;
            
            //fish shock
            if (Input.GetKeyDown(KeyCode.V))
            {
                electricBar.value -= 1;
                progressBar.value -= progressBar.maxValue / 100;
                elctricDelayTimer = electricRecoveryDelay;
                //shock urslef
            }
        }

        if (elctricCanRecov == true)
        {
            electricBar.value += (Time.deltaTime * electricBarRecoveryRate);
        }


        //election
        elctricDelayTimer -= Time.deltaTime;
        if (elctricDelayTimer < 0)
        {
            elctricCanRecov = true;
        }
        else
        {
            elctricCanRecov = false;
        }
    }
    
   

}
