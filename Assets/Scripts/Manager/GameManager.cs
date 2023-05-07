using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool fishIsEating = false;

    public GameObject blood;
    


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void DestroyGO(GameObject go, float delay)
    {
        Destroy(go, delay);
    }
}
