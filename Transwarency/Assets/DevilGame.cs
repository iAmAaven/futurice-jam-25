using TMPro;
using UnityEngine;

public class DevilGame : MonoBehaviour
{
    public int questionAmount = 3;
    public GameObject accept, deny;
    public TextMeshProUGUI questionText;
    public string[] badTexts, goodTexts;
    public SpriteRenderer politicianGFX, tableGFX, windowGFX;
    public Sprite goodSprite, devilSprite, goodTable, badTable, goodWindow, badWindow;
    public bool isGood = false;

    void Start()
    {
        RandomizeAnswer();
    }

    public void RandomizeAnswer()
    {
        if (questionAmount <= 0)
        {
            FindFirstObjectByType<LevelManager>().LevelCompleted();
            accept.SetActive(false);
            deny.SetActive(false);
            return;
        }

        isGood = Random.Range(0, 2) == 0;
        questionAmount--;

        if (isGood)
        {
            politicianGFX.sprite = goodSprite;
            tableGFX.sprite = goodTable;
            windowGFX.sprite = goodWindow;
            questionText.text = goodTexts[Random.Range(0, goodTexts.Length)];
        }
        else
        {
            politicianGFX.sprite = devilSprite;
            tableGFX.sprite = badTable;
            windowGFX.sprite = badWindow;
            questionText.text = badTexts[Random.Range(0, badTexts.Length)];
        }
    }
}
