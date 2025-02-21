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

    void Start()
    {
        timeLeft = lengthOfLevel;
        levelManager = FindFirstObjectByType<LevelManager>();
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        Debug.Log("Waiting 3 seconds for intro to stop...");
        yield return new WaitForSeconds(3f);
        Debug.Log("Starting timer...");

        while (true)
        {
            yield return new WaitForSeconds(1f);
            timeLeft--;
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
