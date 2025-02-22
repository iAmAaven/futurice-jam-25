using UnityEngine;

public class AcceptDevil : MonoBehaviour
{
    public DevilGame devilGame;
    private bool isMouseOver = false, isCorrectAnswer = false;
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

        if (devilGame.isGood)
            isCorrectAnswer = true;
        else
            isCorrectAnswer = false;

        if (Input.GetMouseButtonDown(0) && isMouseOver)
        {
            if (isCorrectAnswer)
            {
                Debug.Log("Correct Answer!");
                devilGame.RandomizeAnswer();
            }
            else
            {
                Debug.Log("Level Failed");
                levelManager.LevelFailed();
            }
        }
    }
    void OnMouseOver()
    {
        isMouseOver = true;
        GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
    }
    void OnMouseExit()
    {
        isMouseOver = false;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    }
}
