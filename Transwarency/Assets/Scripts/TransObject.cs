using UnityEngine;

public class TransObject : MonoBehaviour
{
    public bool isFading = false;
    private bool isMouseOver = false;
    private LevelManager levelManager;
    private LevelLength levelLength;

    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
        levelLength = FindFirstObjectByType<LevelLength>();
    }

    void Update()
    {
        if (levelManager.levelCompleted || levelManager.levelFailed || levelLength.levelStarted == false)
            return;

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
