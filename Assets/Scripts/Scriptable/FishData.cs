using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "FishData", menuName = "ScriptableObjects/FishData", order = 1)]
public class FishData : ScriptableObject
{
    public enum FishType
    {
        Normal,
        Predator,
    }

    [Header("Name")] public string FishName;
    public FishType _FishType;
    
    [Header("Fish Movement Data")]
    [Range(0.1f, 5.0f)]
    public float FishMoveSpeed;

    [Header("Fish Manager Data")]
    
    [Range(0.1f, 5.0f)]
    public float fishMoveDelay_ui = 0.2f;

    public Vector2 fishMoveSpeed_ui = new Vector2(0,100);
    
    [Range(0.1f, 20.0f)]
    public float fishPhaseDelay_ui = 15f;
    
    [Range(0.1f, 20.0f)]
    public float ProgressRate_ui = 0.2f;

    [Header("Food liking")] [Range(1, 100)] 
    public int worm,shrip,octopus;

    [FormerlySerializedAs("minCOinDrop")] [Header("Coin Drop Rate")] 
    public int minCoinDrop = 1;
    public int maxCoinDrop = 50;
   

    
    
        
    public Sprite image;

    

}
