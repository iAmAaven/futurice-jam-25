using UnityEngine;

public class TransObject : MonoBehaviour
{
    public bool isFading = false;
    private bool isMouseOver = false;
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseOver)
        {
            if (isFading)
            {
                levelManager.LevelCompleted();
                Destroy(gameObject);
            }
            else
            {
                levelManager.LevelFailed();
            }
        }
    }
    void OnMouseOver()
    {
        isMouseOver = true;
    }
    public void OnMouseExit()
    {
        isMouseOver = false;
    }
}
