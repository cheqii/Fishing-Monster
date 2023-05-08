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
    
    public void exit()
    {
        Application.Quit();
    }
}
