using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool fishIsEating = false;

    public Fish currentFish;
    
    [Header("Particle Object")]
    public GameObject blood;
    public GameObject explosion;
    public GameObject flash;
    public GameObject coinBurst;
    public GameObject cannobFlash;
    public GameObject bomb;

    [Header("Boat")]
    [SerializeField] private GameObject boat;

    [Header("UI Panel")] 
    [SerializeField] private GameObject gameOverPanel;

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

    private void Update()
    {
        CheckGameEnd();
    }

    void CheckGameEnd()
    {
        if(boat == null) gameOverPanel.SetActive(true);
    }

    public void DestroyGO(GameObject go, float delay)
    {
        Destroy(go, delay);
    }
}
