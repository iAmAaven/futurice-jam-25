using UnityEngine;

public class TransitionAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    void Start()
    {
        float scaleOfTime = Time.timeScale;
        Debug.Log("Time scale in Transition audio: " + scaleOfTime);

        switch (scaleOfTime)
        {
            case 1f:
                audioSource.clip = audioClips[0];
                break;
            case >= 1.2f and < 1.4f:
                Debug.Log("Audio clip: 1.2x");
                audioSource.clip = audioClips[1];
                break;
            case >= 1.4f and < 1.6f:
                Debug.Log("Audio clip: 1.4x");
                audioSource.clip = audioClips[2];
                break;
            case >= 1.6f and < 1.8f:
                Debug.Log("Audio clip: 1.6x");
                audioSource.clip = audioClips[3];
                break;
            case >= 1.8f and < 2f:
                Debug.Log("Audio clip: 1.8x");
                audioSource.clip = audioClips[4];
                break;
            case >= 2f:
                Debug.Log("Audio clip: 2.0x");
                audioSource.clip = audioClips[5];
                break;
            default:
                Debug.Log("Audio clip: default");
                audioSource.clip = audioClips[0];
                break;
        }

        audioSource.Play();
    }
}
