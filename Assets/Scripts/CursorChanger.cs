using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public static CursorChanger Instance { get; private set; }

    
    public Texture2D defalutCursorTexture;
    public Texture2D rodeCursor;
    public Texture2D hand;
    public Texture2D cannon;



    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    
    
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        Cursor.SetCursor(defalutCursorTexture, hotSpot, cursorMode);
    }

    public void ChangeToRodeCursor()
    {
        Cursor.SetCursor(rodeCursor, Vector2.zero, cursorMode);
    }
    
    public void ChangeTohandCursor()
    {
        Cursor.SetCursor(hand, Vector2.zero, cursorMode);
    }
    
    public void ChangeTocannonCursor()
    {
        Cursor.SetCursor(cannon, Vector2.zero, cursorMode);
    }
}