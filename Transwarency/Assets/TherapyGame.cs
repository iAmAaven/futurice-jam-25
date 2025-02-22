using TMPro;
using UnityEngine;

public class TherapyGame : MonoBehaviour
{
    public TextMeshProUGUI speechText;
    [TextArea]
    public string sentence;
    public SpriteRenderer therapistGFX;
    public Sprite therapistHappy;
    private int index = 0;
    private LevelLength levelLength;
    private LevelManager levelManager;

    void Start()
    {
        levelLength = FindFirstObjectByType<LevelLength>();
        levelManager = FindFirstObjectByType<LevelManager>();
        speechText.text = "";
    }

    void Update()
    {
        if (speechText.text.Length >= sentence.Length || levelLength.levelStarted == false
            || levelManager.levelFailed == true || levelManager.levelCompleted == true)
            return;

        if (Input.anyKeyDown)
        {
            speechText.text += sentence[index];
            index++;

            if (index == sentence.Length)
            {
                levelManager.LevelCompleted();
                therapistGFX.sprite = therapistHappy;
            }
        }
    }
}
