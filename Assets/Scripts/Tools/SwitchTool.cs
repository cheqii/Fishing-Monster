using TMPro;
using UnityEngine;

public enum Tools
{
    Rod,
    Bomb,
    Hand
}
public class SwitchTool : Singleton<SwitchTool>
{
    [SerializeField] private Tools toolTypes = Tools.Rod;
    [SerializeField] private TextMeshProUGUI text;

    public Tools ToolTypes
    {
        get => toolTypes;
        set => toolTypes = value;
    }

    private void Start()
    {
        text.text = toolTypes.ToString();
    }

    public void Switch()
    {
        if (toolTypes == Tools.Rod)
        {
            toolTypes = Tools.Bomb;
            text.text = "Bomb";
        }
            
        else if (toolTypes == Tools.Bomb)
        {
            toolTypes = Tools.Hand;
            text.text = "Hand";
        }
        else
        {
            toolTypes = Tools.Rod;
            text.text = "Rod";
        }
    }
}
