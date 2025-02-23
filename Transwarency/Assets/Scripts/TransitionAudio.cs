using UnityEngine;

public class TransitionAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    void Start()
    {
        float scaleOfTime = Time.timeScale;

        switch (scaleOfTime)
        {
            case 1f:
                audioSource.clip = audioClips[0];
                break;
            case 1.2f:
                audioSource.clip = audioClips[1];
                break;
            case 1.4f:
                audioSource.clip = audioClips[2];
                break;
            case 1.6f:
                audioSource.clip = audioClips[3];
                break;
            case 1.8f:
                audioSource.clip = audioClips[4];
                break;
            case 2f:
                audioSource.clip = audioClips[5];
                break;
            default:
                audioSource.clip = audioClips[0];
                break;
        }
    }
}
