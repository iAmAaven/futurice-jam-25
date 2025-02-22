using UnityEngine;

public class StampGame : MonoBehaviour
{
    public int paperAmount = 10;
    public Animator stampAnim;
    public Animator[] paperAnims;
    private bool levelCompleted = false;
    private LevelLength levelLength;

    void Start()
    {
        levelLength = FindFirstObjectByType<LevelLength>();
    }

    public void Stamp()
    {
        stampAnim.SetTrigger("Stamp");
        paperAmount--;
        paperAnims[paperAmount].SetTrigger("Stamp");
        Destroy(paperAnims[paperAmount].gameObject, 0.5f);
    }

    void Update()
    {
        if (levelLength.levelStarted == false || levelCompleted)
            return;

        if (paperAmount <= 0)
        {
            levelCompleted = true;
            FindFirstObjectByType<LevelManager>().LevelCompleted();
            return;
        }
        if (Input.GetMouseButtonDown(0) && paperAmount > 0)
        {
            Stamp();
        }
    }
}
