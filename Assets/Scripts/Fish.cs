using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    [SerializeField] public FishData _fishData;
    [SerializeField] private float fishMoveSpeed;

    [SerializeField] private Texture2D fishTexture;
    [SerializeField] public Material fishmesh;

    public Material newMat;

    public float fishExtraSpeed = 1;

    private CoinBomb coinBomb;
    
    public bool isDead = false;

    public bool isHitBoat = false;

    
    // [SerializeField] private int minCoinDrop = 1;
    // [SerializeField] private int maxCoinDrop = 10;

    public enum FishDirection
    {
        left,
        right
    }

    public FishDirection _Direction;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        coinBomb = GetComponent<CoinBomb>();
        
        fishMoveSpeed = _fishData.FishMoveSpeed + Random.Range(0, _fishData.FishMoveSpeed) ;

        
        var fishMesh = new Material(fishmesh);
        newMat = fishMesh;
        fishMesh.SetTexture("_Texture" ,fishTexture);
        
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<SpriteRenderer>() != null)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().material = fishMesh;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_Direction == FishDirection.left)
        {
            this.transform.position += Vector3.left * (Time.deltaTime * fishMoveSpeed *  fishExtraSpeed);
        }
        else
        {
            this.transform.position += Vector3.right * (Time.deltaTime * fishMoveSpeed * fishExtraSpeed);

        }
    }

    public FishData GetFishData()
    {
        return _fishData;
    }

    public Vector3 getCenter()
    {
        Vector3 sumVector = new Vector3(0f,0f,0f);
        int childCount = 0;

        foreach (Transform child in this.gameObject.transform)
        {
            if (child.name != "Radar")
            {
                sumVector += child.position;
                childCount++;
            }
               
        }

        Vector3 groupCenter = sumVector / childCount;
        childCount = 0;

        return groupCenter;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Boat"))
        {
            isHitBoat = true;
            FindObjectOfType<FisherManAnime>().Idle(1);
        }
    }
}
