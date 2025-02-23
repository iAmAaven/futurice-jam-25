using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip[] musicClips;
    private bool musicStarted = false;
    private LevelLength levelLength;

    void Start()
    {
        levelLength = FindFirstObjectByType<LevelLength>();
        float scaleOfTime = Time.timeScale;

        switch (scaleOfTime)
        {
            case 1.0f:
                musicSource.clip = musicClips[0];
                break;
            case >= 1.2f and < 1.4f:
                musicSource.clip = musicClips[1];
                break;
            case >= 1.4f and < 1.6f:
                musicSource.clip = musicClips[2];
                break;
            case >= 1.6f and < 1.8f:
                musicSource.clip = musicClips[3];
                break;
            case >= 1.8f and < 2f:
                musicSource.clip = musicClips[4];
                break;
            case >= 2f:
                musicSource.clip = musicClips[5];
                break;
            default:
                musicSource.clip = musicClips[0];
                break;
        }
    }

    void Update()
    {
        if (levelLength.levelStarted && !musicStarted)
        {
            musicSource.Play();
            musicStarted = true;
        }
    }
}
