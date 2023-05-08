using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] level;
    [SerializeField] private Animator transition;
    private int currentLevel = 1;


    public void Back()
    {
        if (currentLevel > 1)
        {
            ChangeLevelTo(currentLevel - 1);
        }
    }
    
    public void Forward()
    {
        if (currentLevel < level.Length)
        {
            ChangeLevelTo(currentLevel + 1);
        }
    }

    public void ChangeLevelTo(int lv)
    {
        transition.SetTrigger("Transition");
            
        foreach (var i in level)
        {
            i.SetActive(false);
        }

        var allFish = FindObjectsByType<Fish>(FindObjectsSortMode.None);


        foreach (var i in allFish)
        {
            Destroy(i.gameObject);
        }
        level[lv].SetActive(true);

        currentLevel = lv;
    }
}
