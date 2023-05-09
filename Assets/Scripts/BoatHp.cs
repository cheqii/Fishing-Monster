using System;
using System.Collections;
using Unity.Mathematics;
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
    public GameObject boat;
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
            var bomb = Instantiate(GameManager.Instance.bomb, transform.position, quaternion.identity);
            bomb.transform.localScale *= 3;
            bomb.GetComponentInChildren<Explosion>().ExplosionReady();
            var blood = Instantiate(GameManager.Instance.blood,transform.position, quaternion.identity);
            blood.GetComponent<ParticleSystem>().loop = false;
            fillImage.enabled = false;
            Destroy(slider.gameObject);
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        var fish = col.gameObject.GetComponent<Fish>();
        if(fish == null) return;
        if (fish._fishData._FishType == FishData.FishType.Predator)
        {
            fishBiteDelay -= Time.deltaTime;

            if (fishBiteDelay < 0)
            {
                DecreaseHp(10);
                fishBiteDelay = 5;
            }
        
        }
        
    }

}
