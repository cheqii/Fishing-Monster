using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherManAnime : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private Rod _rod;
    private bool temp;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        
        _animator.SetTrigger("idle");
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            if (hit &&  isOverUI == true)
            {
                Debug.Log("UI");
                return;
            }
            
            
            if (SwitchTool.Instance.ToolTypes == Tools.Rod)
            {
                if(_rod.IsFishing == true) return;
                Throw(1);
            }
            else if (SwitchTool.Instance.ToolTypes == Tools.Bomb)
            {
                if(_rod.IsFishing == true) return;
                ThrowBait();
            }
                
        }
      
    }

    public void Idle(float speed)
    {
        _animator.SetTrigger("idle");
        _animator.speed = speed;
    }
    
    public void Throw(float speed)
    {
        _animator.SetTrigger("throw");
        _animator.speed = speed;
    }
    
    public void Fighting(float speed)
    {
        _animator.SetTrigger("fighting");
        _animator.speed = speed;
    }
    
    public void Cannon(float speed)
    {
        var Explosion = Instantiate(GameManager.Instance.cannobFlash, _rod.throwingPoint.position ,Quaternion.identity);
        
        _animator.SetTrigger("cannon");
        _animator.speed = speed;
    }

    public void ThrowBait()
    {
        _rod.ClickBait();

    }




}
