using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    private List<int> levels = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private LevelSelector instance;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void ChooseLevel()
    {
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
