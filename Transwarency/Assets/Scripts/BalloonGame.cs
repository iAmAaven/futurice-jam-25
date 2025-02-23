using UnityEngine;

public class BalloonGame : MonoBehaviour
{
    public int balloonAmount = 3;
    private bool allPopped = false;
    private bool isMouseOver = false;
    private GameObject balloon;
    private LevelLength levelLength;
    private LevelManager levelManager;

    void Start()
    {
        levelLength = FindFirstObjectByType<LevelLength>();
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    void Update()
    {
        if (allPopped || levelLength.levelStarted == false
            || levelManager.levelCompleted || levelManager.levelFailed)
            return;

        if (Input.GetMouseButtonDown(0) && isMouseOver)
        {
            Destroy(balloon);
            balloonAmount--;
            if (balloonAmount <= 0)
            {
                allPopped = true;
                FindFirstObjectByType<LevelManager>().LevelCompleted();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            balloon = collision.gameObject;
            isMouseOver = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            isMouseOver = false;
        }
    }
}
