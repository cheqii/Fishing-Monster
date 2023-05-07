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
        coinSystem = CoinSystem.Instance;
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
            var button = items[i].transform.Find("Button");
            if (coinSystem.CurrentMoney >= itemData[i].price)
            {
                button.GetComponent<Image>().color = Color.green;
            }
            else
            {
                button.GetComponent<Image>().color = Color.red;
                button.GetComponentInChildren<TextMeshProUGUI>().text = "no money";
            }
        }
    }

    public void PurchaseItem(int id)
    {
        if (coinSystem.CurrentMoney >= itemData[id].price)
        {
            Debug.Log("Purchased Item id : " + itemData[id].itemId);
            coinSystem.DecreaseMoney(itemData[id].price);
        }
        else
        {
            Debug.Log("Not Enough Money");
        }
    }

    
}
