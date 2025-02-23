using UnityEngine;

public class LaserPacket : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            FindFirstObjectByType<LevelManager>().LevelFailed();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            FindFirstObjectByType<LevelManager>().LevelCompleted();
        }
    }
}
