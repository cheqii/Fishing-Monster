using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMeuScene : MonoBehaviour
{
    public void ChangeScenes(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
    public void OpenUI(GameObject ui)
    {
        ui.SetActive(true);
    }
    
    public void CloseUI(GameObject ui)
    {
        ui.SetActive(false);
    }
}
