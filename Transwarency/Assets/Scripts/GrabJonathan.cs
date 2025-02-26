using UnityEngine;

public class GrabJonathan : MonoBehaviour
{
    public FollowMouse followMouse;
    public GameObject textObject;
    private bool isHovering = false;
    private bool jonathanGrabbed = false, levelCompleted = false;
    private LevelLength levelLength;
    private LevelManager levelManager;

    void Start()
    {
        levelLength = FindFirstObjectByType<LevelLength>();
        levelManager = FindFirstObjectByType<LevelManager>();
        followMouse.enabled = false;
    }

    void Update()
    {
        if (jonathanGrabbed == true || levelLength.levelStarted == false)
            return;

        if (isHovering && Input.GetMouseButtonDown(0))
        {
            textObject.SetActive(false);
            followMouse.enabled = true;
            jonathanGrabbed = true;
            Cursor.visible = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (levelCompleted == true
            || levelManager.levelFailed
            || levelManager.levelCompleted)
            return;

        if (other.gameObject.tag == "Goal")
        {
            FindFirstObjectByType<LevelManager>().LevelCompleted();
            levelCompleted = true;
            Cursor.visible = true;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Wall")
        {
            FindFirstObjectByType<LevelManager>().LevelFailed();
            Cursor.visible = true;
            Destroy(gameObject);
        }
    }

    void OnMouseOver()
    {
        isHovering = true;
    }
    void OnMouseExit()
    {
        isHovering = false;
    }
}
