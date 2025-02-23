using UnityEngine;

public class FoggyWindow : MonoBehaviour
{
    public GameObject sponge;
    public SpriteRenderer dirtyWindow;
    private bool isHovering = false;
    private Rigidbody2D player;
    private float dirtyWindowAlpha = 1f;
    private float scrubbingTime = 0f;
    private const float scrubInterval = 0.1f;

    private bool windowScrubbed = false;
    private LevelLength levelLength;
    private LevelManager levelManager;

    void Start()
    {
        Cursor.visible = false;
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        levelLength = FindFirstObjectByType<LevelLength>();
        levelManager = FindFirstObjectByType<LevelManager>();
    }
    void Update()
    {
        if (windowScrubbed || levelLength.levelStarted == false
            || levelManager.levelCompleted || levelManager.levelFailed)
            return;

        if (dirtyWindow.color.a <= 0f)
        {
            Debug.Log("Win!");
            Cursor.visible = true;
            Destroy(sponge);
            levelManager.LevelCompleted();
            windowScrubbed = true;
            return;
        }
        if (Input.GetMouseButton(0) && player.linearVelocity.magnitude > 0.1f && isHovering)
        {
            scrubbingTime += Time.deltaTime;
            if (scrubbingTime >= scrubInterval)
            {
                dirtyWindowAlpha -= 0.1f;
                dirtyWindow.color = new Color(1f, 1f, 1f, dirtyWindowAlpha);
                scrubbingTime = 0f;
            }
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
