using TMPro;
using UnityEngine;

public class DevilGame : MonoBehaviour
{
    public Animator[] paperAnims;
    public int questionAmount = 3;
    public GameObject accept, deny;
    public TextMeshProUGUI questionText;
    public string[] badTexts, goodTexts;
    public SpriteRenderer politicianGFX, tableGFX, windowGFX;
    public Sprite[] goodSprites;
    public Sprite devilSprite, goodTable, badTable, goodWindow, badWindow;
    public bool isGood = false;

    void Start()
    {
        RandomizeAnswer();
    }

    public void RandomizeAnswer()
    {
        if (questionAmount < 3)
        {
            if (isGood)
                paperAnims[questionAmount].SetTrigger("Good");
            else
                paperAnims[questionAmount].SetTrigger("Bad");
        }

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
            politicianGFX.sprite = goodSprites[Random.Range(0, goodSprites.Length)];
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
