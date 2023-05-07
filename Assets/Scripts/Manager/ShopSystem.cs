using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    private CoinSystem coinSystem;
    [SerializeField] private GameObject[] items;

    [SerializeField] private ItemData[] itemData;

    private void Start()
    {
        coinSystem = GetComponent<CoinSystem>();
        SetupShop();
    }

    private void Update()
    {
        CheckItem();
    }

    void SetupShop()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].transform.Find("Image").GetComponentInChildren<Image>().sprite = itemData[i].itemImage;
            items[i].GetComponentInChildren<TextMeshProUGUI>().text = "$ " + itemData[i].price;
        }
    }

    void CheckItem()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (coinSystem.CurrentMoney >= itemData[i].price)
            {
                items[i].transform.Find("Button").GetComponentInChildren<Image>().color = Color.green;
            }
            else
            {
                items[i].transform.Find("Button").GetComponentInChildren<Image>().color = Color.red;
            }
        }
    }

    public void PurchaseItem()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (coinSystem.CurrentMoney >= itemData[i].price)
            {
                Debug.Log("Purchased Item id : " + itemData[i].itemId);
                coinSystem.DecreaseMoney(itemData[i].price);
            }
            else
            {
                Debug.Log("Not Enough Money");
            }
        }
    }
}
