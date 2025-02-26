using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float speed = 50f;
    private Rigidbody2D rb;
    private Vector3 mousePos;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePos - transform.position).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction.x * speed, direction.y * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
