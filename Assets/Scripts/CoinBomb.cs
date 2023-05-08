using UnityEngine;

public class CoinBomb : MonoBehaviour
{
    [SerializeField] private int resourceCount;
    [SerializeField] private GameObject resourceNode;

    private ParticleSystem pfx;
    private int amountCoin = 0;
    private void Start()
    {
        pfx = GetComponentInChildren<ParticleSystem>();
    }

    public void DropCoins(int value)
    {
        Debug.Log("Drop Coins");
        int amountToSpawn = Mathf.Min(value, resourceCount - amountCoin);
        if (amountToSpawn > 0)
        {
            Debug.Log("1");
            pfx.Emit(value);
            amountCoin += amountToSpawn;
        }

        if (amountCoin >= resourceCount)
        {
            Debug.Log("2");
            Destroy(gameObject);
        }
    }
}
