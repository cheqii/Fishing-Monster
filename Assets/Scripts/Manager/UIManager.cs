using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject fishingMiniGame;

    private void Update()
    {
        if (GameManager.Instance.fishIsEating == true && GameManager.Instance.Boat != null)
        {
            fishingMiniGame.SetActive(true);
        }
        else
        {
            fishingMiniGame.SetActive(false);
        }
    }
}
