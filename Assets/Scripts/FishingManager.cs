using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishingManager : MonoBehaviour
{
    [SerializeField] private Transform fishUi;
    [SerializeField] private Transform catchUi;

    
    [Header("fish")]
    [SerializeField] private float fishMoveDelay = 0.2f;
    [SerializeField] private Vector2 fishMoveSpeed = new Vector2(0,100);
    [SerializeField] private float fishPhaseDelay = 15f;
    
    
    private Vector3 fishDestination;
    private Vector3 fishStartPoint;
    
    private bool fishIsFighing = false;

    
    [Header("catch")]
    [SerializeField] private float catchMovingSpeed = 50;

    private bool reverseCatch = false;

    

    





    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FishMove());
        StartCoroutine(FishBehevior());

    }
    
    void OnEnable()
    {
        StartCoroutine(FishMove());
        StartCoroutine(FishBehevior());
    }

    // Update is called once per frame
    void Update()
    {
      
        
        
        if (reverseCatch == true)
        {
            catchUi.eulerAngles += new Vector3(0,0,Time.deltaTime * catchMovingSpeed);
        }
        else
        {
            catchUi.eulerAngles -= new Vector3(0,0,Time.deltaTime * catchMovingSpeed);
        }

        
        fishUi.eulerAngles = new Vector3(
            Mathf.LerpAngle(0, 0, Time.deltaTime),
            Mathf.LerpAngle(0, 0, Time.deltaTime),
            Mathf.LerpAngle(fishUi.eulerAngles.z, fishDestination.z, Time.deltaTime));
       
        


        if (Input.GetKey(KeyCode.Space))
        {
            reverseCatch = true;
        }
        else
        {
            reverseCatch = false;
        }

        
      
    }


    IEnumerator FishMove()
    {
        while (true)
        {
            if (fishIsFighing == true)
            {
                if (Random.Range(0, 6) == 1)
                {
                    fishDestination = new Vector3(0, 0, fishUi.transform.eulerAngles.z + Random.Range(fishMoveSpeed.x,fishMoveSpeed.y));
                }

                else
                {
                    fishDestination = new Vector3(0, 0, fishUi.transform.eulerAngles.z - Random.Range(fishMoveSpeed.x,fishMoveSpeed.y));
                }
            }
            else
            {
                if (Random.Range(0, 6) == 1)
                {
                    fishDestination = new Vector3(0, 0,
                        fishUi.transform.eulerAngles.z - Random.Range(fishMoveSpeed.x, fishMoveSpeed.y));
                }
                else
                {
                    fishDestination = new Vector3(0, 0,
                        fishUi.transform.eulerAngles.z + Random.Range(fishMoveSpeed.x, fishMoveSpeed.y));
                }
            }

            fishStartPoint = fishUi.eulerAngles;

            yield return new WaitForSeconds(fishMoveDelay);
        }
    }

    IEnumerator FishBehevior()
    {
        while (true)
        {
            if (fishIsFighing == true)
            {
                fishIsFighing = false;
            }
            else
            {
                fishIsFighing = true;

            }
        
            yield return new WaitForSeconds(fishPhaseDelay);
        }
        

    }


}
