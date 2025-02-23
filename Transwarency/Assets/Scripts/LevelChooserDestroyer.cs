using UnityEngine;

public class LevelChooserDestroyer : MonoBehaviour
{
    void Start()
    {
        if (GameObject.Find("LevelChooser") != null)
            Destroy(GameObject.Find("LevelChooser"));
    }
}
