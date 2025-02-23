using UnityEngine;

public class LaserButton : MonoBehaviour
{
    public Collider2D laserCollider;
    public SpriteRenderer laserSpriteRenderer;
    public Sprite laserOnSprite, laserOffSprite;

    private bool isHovering = false;
    private LevelLength levelLength;
    private LevelManager levelManager;

    void Start()
    {
        levelLength = FindFirstObjectByType<LevelLength>();
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    void Update()
    {
        if (levelLength.levelStarted == false || levelManager.levelCompleted
            || levelManager.levelFailed)
        {
            laserCollider.enabled = true;
            laserSpriteRenderer.sprite = laserOnSprite;
            return;
        }

        if (isHovering)
        {
            if (Input.GetMouseButton(0))
            {
                laserCollider.enabled = false;
                laserSpriteRenderer.sprite = laserOffSprite;
            }
            else
            {
                laserCollider.enabled = true;
                laserSpriteRenderer.sprite = laserOnSprite;
            }
        }
        else
        {
            laserCollider.enabled = true;
            laserSpriteRenderer.sprite = laserOnSprite;
        }
    }

    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
        isHovering = true;
    }
    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        isHovering = false;
    }
}
