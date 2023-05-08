using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BoatHp : MonoBehaviour
{
    [SerializeField] private int boatFullHp;
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;
    [SerializeField] private int _boatCurrentHp;
    private GameObject boat;
    bool takedamage = false;
    int valueToLerp = 0;
    
    private float fishBiteDelay = 5;
    
    void Start()
    {
        // boat = GameObject.FindGameObjectWithTag("Boat");
        _boatCurrentHp = boatFullHp;
        slider.value = _boatCurrentHp;
    }

    private void Update()
    {
        if(takedamage)
        {
            Debug.Log("Lerp");
            StartCoroutine(LerpHp());
        }
    }

    IEnumerator LerpHp()
    {
        //lerp slider value
        slider.value = Mathf.Lerp(slider.value, _boatCurrentHp, Time.deltaTime);
        yield return new WaitForSeconds(0.01f);
    }

    public void DecreaseHp(int damage)
    {
        takedamage = true;
        slider.value = _boatCurrentHp; // old hp before take damage
        _boatCurrentHp -= damage;
        if (slider.value <= 0)
        {
            fillImage.enabled = false;
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log(col.name);
        var fish = col.gameObject.GetComponent<Fish>();
        if(fish == null) return;
        if (fish._fishData._FishType == FishData.FishType.Predator)
        {
            fishBiteDelay -= Time.deltaTime;

            if (fishBiteDelay < 0)
            {
                DecreaseHp(5);
                fishBiteDelay = 5;
            }
        
        }
        
    }

}
