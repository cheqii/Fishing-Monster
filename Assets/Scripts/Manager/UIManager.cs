using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    public void SelectScene (string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void RestartGame(string sceneName)
    {
        CoinSystem.Instance.DecreaseMoney(CoinSystem.Instance.CurrentMoney / 4);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
