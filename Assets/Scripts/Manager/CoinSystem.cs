using TMPro;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private int currentMoney;

    private void Start()
    {
        coinText.text = currentMoney.ToString() + " $";
    }

    public void IncreaseMoney(int value)
    {
        currentMoney += value;
        coinText.text = currentMoney.ToString() + " $";
    }

    public void DecreaseMoney(int value)
    {
        if (currentMoney > 0) currentMoney -= value;
        coinText.text = currentMoney.ToString() + " $";
    }
}
