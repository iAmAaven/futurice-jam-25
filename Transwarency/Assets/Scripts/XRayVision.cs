using UnityEngine;

public class XRayVision : MonoBehaviour
{
    public SpriteRenderer screenGFX;
    public Sprite[] sprites;
    public int caseAmount = 3;
    public bool isSafe = false;
    public Animator hihnaAnim;

    void Start()
    {
        RandomizeCase();
    }

    public void RandomizeCase()
    {
        if (caseAmount != 3)
            hihnaAnim.SetTrigger("NextCase");

        if (caseAmount <= 0)
        {
            FindFirstObjectByType<LevelManager>().LevelCompleted();
            screenGFX.sprite = null;
            return;
        }

        isSafe = Random.Range(0, 2) == 0;
        caseAmount--;
        if (!isSafe)
        {
            screenGFX.sprite = sprites[0];
        }
        else
        {
            screenGFX.sprite = sprites[Random.Range(1, sprites.Length)];
        }
    }
}
