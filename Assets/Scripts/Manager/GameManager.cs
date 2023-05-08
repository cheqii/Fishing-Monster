using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool fishIsEating = false;

    public Fish currentFish;
    
    [Header("Particle Object")]
    public GameObject blood;
    public GameObject explosion;
    public GameObject flash;
    public GameObject cannobFlash;

    [Header("Boat")]
    [SerializeField] private GameObject boat;

    public GameObject Boat
    {
        get => boat;
        set => boat = value;
    }

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
