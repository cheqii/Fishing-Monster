using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum BaitTypes
{
    Worm = 1,
    Shrimp = 2,
    Octopus = 3
}
[CreateAssetMenu(fileName = "BaitData", menuName = "ScriptableObjects/BaitData", order = 2)]
public class BaitData : ScriptableObject
{
    public BaitTypes baitType;
    public Sprite baitSprite;
}
