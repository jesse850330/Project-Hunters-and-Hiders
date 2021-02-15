using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UI_Scripts_AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider MasterVolumeSlider;
    public Slider BackgroundSlider;
    public Slider SoundEffectSlider;

    void Start()
    {
        MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        BackgroundSlider.value = PlayerPrefs.GetFloat("Background");
        SoundEffectSlider.value = PlayerPrefs.GetFloat("SoundEffect");
    }

    void Update()
    {
        PlayerPrefs.SetFloat("MasterVolume", MasterVolumeSlider.value);
        PlayerPrefs.SetFloat("Background", BackgroundSlider.value);
        PlayerPrefs.SetFloat("SoundEffect", SoundEffectSlider.value);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Background", volume);
    }

    public void SetSoundEffectVolume(float volume)
    {
        audioMixer.SetFloat("SoundEffect", volume);
    }
}
