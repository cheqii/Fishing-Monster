using TMPro;
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

            if (!itemData[i].isLocked)
            {
                items[i].transform.Find("Lock Icon").gameObject.SetActive(false);
            }
            else
            {
                items[i].transform.Find("Lock Icon").gameObject.SetActive(true);
            }
            items[i].transform.Find("Image").GetComponentInChildren<Image>().sprite = itemData[i].itemImage;
            items[i].GetComponentInChildren<TextMeshProUGUI>().text = "$ " + itemData[i].price;
        }
    }

    void CheckItem()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (!itemData[i].isLocked)
            {
                items[i].transform.Find("Lock Icon").gameObject.SetActive(false);
                items[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
            else
            {
                items[i].transform.Find("Lock Icon").gameObject.SetActive(true);
            }
        }
    }

    public void PurchaseItem(int id)
    {
        if (coinSystem.CurrentMoney >= itemData[id].price && itemData[id].isLocked)
        {
            Debug.Log("Purchased Item id : " + itemData[id].itemId);
            coinSystem.DecreaseMoney(itemData[id].price);
            itemData[id].isLocked = false;
            items[id].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        }
        else
        {
            if(coinSystem.CurrentMoney < itemData[id].price) Debug.Log("Not enough money");
            else Debug.Log("Item already purchased");
            
        }
    }
    
    public void ChangeBait(int id)
    {
        // change bait data
        var rod = GameManager.Instance.Boat.GetComponentInChildren<Rod>();
        rod.BaitData = itemData[id].baitData;
        Debug.Log(rod.BaitData);
    }

    
}
