using TMPro;
using UnityEngine;

public class DateGame : MonoBehaviour
{
    public GameObject bubble;
    public SpriteRenderer jonathanGFX, dateGFX;
    public Sprite jonathanHappy, jonathanSad, dateHappy, dateSad;
    public TextMeshProUGUI letterText;
    public int amountOfLetters = 5;
    private char[] allChars = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
    private LevelLength levelLength;
    private LevelManager levelManager;

    void Start()
    {
        levelLength = FindFirstObjectByType<LevelLength>();
        levelManager = FindFirstObjectByType<LevelManager>();
        RandomizeLetter();
    }

    void Update()
    {
        if (levelLength.levelStarted == false || levelManager.levelCompleted
            || levelManager.levelFailed)
            return;

        if (Input.anyKeyDown)
        {
            if (Input.inputString.ToLower() == letterText.text.ToLower())
            {
                amountOfLetters--;
                if (amountOfLetters <= 0)
                {
                    levelManager.LevelCompleted();
                    bubble.SetActive(false);
                    jonathanGFX.sprite = jonathanHappy;
                    dateGFX.sprite = dateHappy;
                    return;
                }
                RandomizeLetter();
            }
            else
            {
                jonathanGFX.sprite = jonathanSad;
                dateGFX.sprite = dateSad;
                bubble.SetActive(false);
                levelManager.LevelFailed();
            }
        }
    }

    void RandomizeLetter()
    {
        letterText.text = allChars[Random.Range(0, allChars.Length)].ToString();
    }
}
