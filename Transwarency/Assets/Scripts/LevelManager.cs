using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Animations")]
    public Animator anim;
    [Header("Audio")]
    public AudioSource levelFinishAudio;
    public AudioClip failAudio, successAudio;
    [Header("References")]
    public GameObject levelChooserPrefab;

    [HideInInspector]
    public bool levelCompleted = false, levelFailed = false;

    void Start()
    {
        if (LevelChooser.instance == null)
            Instantiate(levelChooserPrefab);

        FindFirstObjectByType<HealthBar>().RefreshHealth(LevelChooser.instance.health);
        GameObject.FindWithTag("LevelText").GetComponent<TextMeshProUGUI>().text = "" + LevelChooser.instance.currentLevel;
    }

    public void LevelCompleted()
    {
        levelCompleted = true;

        if (levelFinishAudio != null)
        {
            levelFinishAudio.clip = successAudio;
            levelFinishAudio.Play();
        }
        if (anim != null)
            anim.SetTrigger("LevelCompleted");

        LevelChooser.instance.ChooseLevel();
    }

    public void LevelFailed()
    {
        levelFailed = true;

        if (levelFinishAudio != null)
        {
            levelFinishAudio.clip = failAudio;
            levelFinishAudio.Play();
        }
        // if (anim != null)
        //     anim.SetTrigger("LevelFailed");

        LevelChooser.instance.LoseHealth();
        LevelChooser.instance.ChooseLevel();
    }
}
