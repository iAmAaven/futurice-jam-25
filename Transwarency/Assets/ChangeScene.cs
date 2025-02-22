using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void SceneChange(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
