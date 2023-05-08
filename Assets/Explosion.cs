using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float bombTimer = 0.1f;
    [SerializeField] private bool explosion = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bombTimer -= Time.deltaTime;

        if (bombTimer < 0)
        {
            ExplosionReady();
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(explosion == false) return;
        
        var _fishRadar = col.GetComponent<FishRadar>();
        if (_fishRadar != null)
        {
            var _fish = col.gameObject.transform.parent;

            

            
            var _blood = Instantiate(GameManager.Instance.blood,
                _fish.GetComponent<Fish>().getCenter(),
                Quaternion.identity);
            Destroy(_fish.gameObject);
            _blood.GetComponent<ParticleSystem>().loop = false;
            GameManager.Instance.DestroyGO(_blood,10);
        }
    }

    public void ExplosionReady()
    {
        explosion = true;
        var _blood = Instantiate(  GameManager.Instance.explosion,this.transform.position, Quaternion.identity);
        GameManager.Instance.DestroyGO(_blood,10f);

      
        GameManager.Instance.DestroyGO(transform.parent.gameObject,0.1f);
    }
}
