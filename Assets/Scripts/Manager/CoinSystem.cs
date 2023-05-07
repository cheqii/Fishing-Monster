using TMPro;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private int currentMoney;

    public int CurrentMoney
    {
        get => currentMoney;
        set => currentMoney = value;
    }

    private void Start()
    {
        currentMoney = PlayerPrefs.GetInt("money", 0);
        coinText.text = currentMoney + " $";
    }

    public void IncreaseMoney(int value)
    {
        currentMoney += value;
        coinText.text = currentMoney + " $";
        PlayerPrefs.SetInt("money", currentMoney);
    }

    public void DecreaseMoney(int value)
    {
        if (currentMoney > 0) currentMoney -= value;
        coinText.text = currentMoney + " $";
        PlayerPrefs.SetInt("money", currentMoney);
    }
}
