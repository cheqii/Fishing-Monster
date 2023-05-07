using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Tools
{
    Rod,
    Bomb,
    Hand
}
public class SwitchTool : MonoBehaviour
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
        text.GetComponentInParent<Image>().color = Color.red;
    }

    public void Switch()
    {
        if (toolTypes == Tools.Rod)
        {
            toolTypes = Tools.Bomb;
            text.text = "Bomb";
            text.GetComponentInParent<Image>().color = Color.yellow;
        }
            
        else if (toolTypes == Tools.Bomb)
        {
            toolTypes = Tools.Hand;
            text.text = "Hand";
            text.GetComponentInParent<Image>().color = Color.white;
        }
        else
        {
            toolTypes = Tools.Rod;
            text.text = "Rod";
            text.GetComponentInParent<Image>().color = Color.red;
        }
    }
}
