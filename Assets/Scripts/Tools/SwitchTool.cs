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
    }

    public void SwitchToBomb()
    {
        toolTypes = Tools.Bomb;
    }

    public void SwitchToHand()
    {
        toolTypes = Tools.Hand;
    }
}
