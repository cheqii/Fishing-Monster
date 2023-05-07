using System;
using UnityEngine;

    public class Coin: MonoBehaviour
    {
        [SerializeField] private int price = 10;

        private void OnMouseDown()
        {
            if(SwitchTool.Instance.ToolTypes != Tools.Hand) return;
            
            CoinSystem.Instance.IncreaseMoney(price);
            Destroy(gameObject);
        }
    }
