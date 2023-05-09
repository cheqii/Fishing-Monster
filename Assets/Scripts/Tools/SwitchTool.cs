using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Tools
{
    Rod,
    Bomb,
    Hand
}
public class SwitchTool : Singleton<SwitchTool>
{
    [SerializeField] private Tools toolTypes = Tools.Rod;

    public Tools ToolTypes
    {
        get => toolTypes;
        set => toolTypes = value;
    }
    
    public void SwitchToRod()
    {
        
        toolTypes = Tools.Rod;
        CursorChanger.Instance.ChangeToRodeCursor();

        
        if(UiCheck() != true)
        {
            FindObjectOfType<FisherManAnime>().Throw(1);
        }

    }

    public void SwitchToBomb()
    {
        toolTypes = Tools.Bomb;
        FindObjectOfType<FisherManAnime>().Cannon(1);
        CursorChanger.Instance.ChangeTocannonCursor();

        if(UiCheck() != true)
        {
            FindObjectOfType<FisherManAnime>().Throw(1);
        }

    }

    public void SwitchToHand()
    {
        toolTypes = Tools.Hand;
        FindObjectOfType<FisherManAnime>().Throw(1);
        CursorChanger.Instance.ChangeTohandCursor();

        if(UiCheck() != true)
        {
            FindObjectOfType<FisherManAnime>().Throw(1);
        }
    }


    public bool UiCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
        if (hit &&  isOverUI == true)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
