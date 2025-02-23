using UnityEngine;

public class Victory : MonoBehaviour
{
    public float timeToWait = 10f;
    void Start()
    {
        Invoke("ChangeToCredits", timeToWait);
    }

    void ChangeToCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditScreen");
    }
}
