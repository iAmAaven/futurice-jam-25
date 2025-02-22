using System.Collections;
using UnityEngine;

public class LevelLength : MonoBehaviour
{
    public int lengthOfLevel = 10;
    public SpriteRenderer timerSprite;
    public Sprite[] sprites;
    private int spriteIndex = 0;
    private int timeLeft;
    private LevelManager levelManager;

    [HideInInspector] public bool levelStarted = false;

    void Start()
    {
        timeLeft = lengthOfLevel;
        levelManager = FindFirstObjectByType<LevelManager>();
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        GameObject.FindWithTag("Intro").SetActive(true);

        Debug.Log("Waiting 5 seconds for intro to stop...");
        yield return new WaitForSeconds(5f);
        levelStarted = true;

        GameObject.FindWithTag("Intro").SetActive(false);

        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (levelManager.levelCompleted || levelManager.levelFailed)
                break;

            timeLeft--;
            Debug.Log("Time left: " + timeLeft);
            if (timeLeft % 2 == 0)
            {
                timerSprite.sprite = sprites[spriteIndex];
                spriteIndex++;
            }

            if (levelManager.levelCompleted || levelManager.levelFailed)
                break;

            if (timeLeft <= 0)
            {
                Debug.Log("Time's up!");
                levelManager.LevelFailed();
                break;
            }
        }
    }
}
