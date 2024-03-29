using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 3)]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int itemId;
    public int price;
    public BaitData baitData;
    public bool isLocked = true;
}
