using System;
using Unity.VisualScripting;
using UnityEngine;

    public class Coin: MonoBehaviour
    {
        [SerializeField] private int price = 10;

        private void Update()
        {
            OnCoin();
        }

        void OnCoin()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (GetComponent<Collider2D>().OverlapPoint(mousePos))
                {
                    if(SwitchTool.Instance.ToolTypes != Tools.Hand) return;
            
                    Debug.Log("Coin");
                    CoinSystem.Instance.IncreaseMoney(price);
                    Destroy(gameObject);
                }
            }
        }
    }
