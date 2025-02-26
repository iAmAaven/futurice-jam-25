using UnityEngine;

public class CustomCursorHandler : MonoBehaviour
{
    public Texture2D customCursorTexture;
    private Vector2 hotspot = Vector2.zero;
    private Rect gameViewport;

    void Start()
    {
        Cursor.SetCursor(customCursorTexture, hotspot, CursorMode.Auto);

        Camera camera = Camera.main;
        gameViewport = camera.pixelRect;
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        if (gameViewport.Contains(mousePosition))
        {
            Cursor.SetCursor(customCursorTexture, hotspot, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
