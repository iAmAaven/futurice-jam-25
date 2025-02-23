using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Animations")]
    public Animator anim;
    [Header("Audio")]
    public AudioSource levelFinishAudio;
    public AudioClip[] failAudios, successAudios;
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
        FindFirstObjectByType<MusicManager>().musicSource.Stop();
        levelCompleted = true;

        if (levelFinishAudio != null)
        {
            float scaleOfTime = Time.timeScale;
            switch (scaleOfTime)
            {
                case 1.0f:
                    levelFinishAudio.clip = successAudios[0];
                    break;
                case >= 1.2f and < 1.4f:
                    levelFinishAudio.clip = successAudios[1];
                    break;
                case >= 1.4f and < 1.6f:
                    levelFinishAudio.clip = successAudios[2];
                    break;
                case >= 1.6f and < 1.8f:
                    levelFinishAudio.clip = successAudios[3];
                    break;
                case >= 1.8f and < 2f:
                    levelFinishAudio.clip = successAudios[4];
                    break;
                case >= 2f:
                    levelFinishAudio.clip = successAudios[5];
                    break;
                default:
                    levelFinishAudio.clip = successAudios[0];
                    break;
            }

            levelFinishAudio.Play();
        }
        if (anim != null)
            anim.SetTrigger("LevelCompleted");

        LevelChooser.instance.ChooseLevel();
    }

    public void LevelFailed()
    {
        levelFailed = true;
        FindFirstObjectByType<MusicManager>().musicSource.Stop();

        if (levelFinishAudio != null)
        {
            float scaleOfTime = Time.timeScale;
            switch (scaleOfTime)
            {
                case 1.0f:
                    levelFinishAudio.clip = failAudios[0];
                    break;
                case >= 1.2f and < 1.4f:
                    levelFinishAudio.clip = failAudios[1];
                    break;
                case >= 1.4f and < 1.6f:
                    levelFinishAudio.clip = failAudios[2];
                    break;
                case >= 1.6f and < 1.8f:
                    levelFinishAudio.clip = failAudios[3];
                    break;
                case >= 1.8f and < 2f:
                    levelFinishAudio.clip = failAudios[4];
                    break;
                case >= 2f:
                    levelFinishAudio.clip = failAudios[5];
                    break;
                default:
                    levelFinishAudio.clip = failAudios[0];
                    break;
            }

            levelFinishAudio.Play();
        }
        // if (anim != null)
        //     anim.SetTrigger("LevelFailed");

        LevelChooser.instance.LoseHealth();
        LevelChooser.instance.ChooseLevel();
    }
}
