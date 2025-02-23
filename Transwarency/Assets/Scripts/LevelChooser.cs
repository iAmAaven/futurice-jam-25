using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChooser : MonoBehaviour
{
    public int health, maxHealth = 3;
    public int currentLevel = 0;
    public int currentRound = 1;
    public bool isStartScene = false;
    private List<int> levels = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private List<int> refillLevels = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public static LevelChooser instance;

    [HideInInspector] public float speedMultiplier = 1f;

    void Start()
    {
        if (instance == null)
        {
            health = maxHealth;
            instance = this;
            if (isStartScene)
                Invoke("ChooseLevel", 2f);
        }
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void ChooseLevel()
    {
        Invoke("ChooseLevelTimer", 4f);
    }
    void ChooseLevelTimer()
    {
        if (currentLevel > 0 && currentLevel % 5 == 0)
        {
            speedMultiplier += 0.2f;
            Debug.Log("Increasing speed to " + speedMultiplier);
            Time.timeScale = speedMultiplier;
        }

        if (health <= 0)
        {
            Debug.Log("No more health left");
            SceneManager.LoadScene("GameOverScene");
            return;
        }

        if (levels.Count == 0)
        {
            if (currentRound < 3)
            {
                currentRound++;
                levels = new List<int>(refillLevels);
                Debug.Log("Refilling levels...");
            }
            else
            {
                Debug.Log("No more levels to play");
                SceneManager.LoadScene("VictoryScene");
                return;
            }
        }

        currentLevel++;
        int randomLevel = levels[Random.Range(0, levels.Count)];
        SceneManager.LoadScene("Level" + randomLevel);
        levels.Remove(randomLevel);
    }

    public void LoseHealth()
    {
        health--;
    }
}
