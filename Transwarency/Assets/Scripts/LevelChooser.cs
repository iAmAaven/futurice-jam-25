using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChooser : MonoBehaviour
{
    public int health, maxHealth = 3;
    public int currentLevel = 1;
    public bool isStartScene = false;
    private List<int> levels = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public static LevelChooser instance;

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
        Invoke("ChooseLevelTimer", 2f);
    }
    void ChooseLevelTimer()
    {
        if (health <= 0)
        {
            Debug.Log("No more health left");
            SceneManager.LoadScene("GameOverScene");
            return;
        }
        if (levels.Count == 0)
        {
            Debug.Log("No more levels to play");
            SceneManager.LoadScene("VictoryScene");
            return;
        }
        int randomLevel = levels[Random.Range(0, levels.Count)];
        SceneManager.LoadScene("Level" + randomLevel);
        levels.Remove(randomLevel);
    }
}
