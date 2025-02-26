using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    void Start()
    {
        LoadAudioSettings();
    }

    void LoadAudioSettings()
    {
        audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume", Mathf.Log10(1) * 20));
        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", Mathf.Log10(1) * 20));
        audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume", Mathf.Log10(1) * 20));
    }
}
