using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private FishData _fishData;
    [SerializeField] private float fishMoveSpeed;

    public enum FishDirection
    {
        left,
        right
    }

    public FishDirection _Direction;
    
    // Start is called before the first frame update
    void Start()
    {
        fishMoveSpeed = _fishData.FishMoveSpeed + Random.Range(0, _fishData.FishMoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (_Direction == FishDirection.left)
        {
            this.transform.position += Vector3.left * (Time.deltaTime * fishMoveSpeed);
        }
        else
        {
            this.transform.position += Vector3.right * (Time.deltaTime * fishMoveSpeed);

        }
    }

    public FishData GetFishData()
    {
        return _fishData;
    }
}
