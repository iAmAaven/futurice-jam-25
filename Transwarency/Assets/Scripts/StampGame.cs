using UnityEngine;

public class StampGame : MonoBehaviour
{
    public int paperAmount = 10;
    public Animator stampAnim;
    public Animator[] paperAnims;
    private LevelManager levelManager;
    private LevelLength levelLength;

    void Start()
    {
        levelLength = FindFirstObjectByType<LevelLength>();
        levelManager = FindFirstObjectByType<LevelManager>();
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
        if (levelLength.levelStarted == false
            || levelManager.levelFailed == true
            || levelManager.levelCompleted == true)
            return;

        if (paperAmount <= 0)
        {
            FindFirstObjectByType<LevelManager>().LevelCompleted();
            return;
        }
        if (Input.GetMouseButtonDown(0) && paperAmount > 0)
        {
            Stamp();
        }
    }
}
