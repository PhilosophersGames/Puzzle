using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SetVolume : MonoBehaviour, EventHandler
{
    public AudioMixer mixer;

    public void SetValue(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFXValue(float sliderValue)
    {
        mixer.SetFloat("SfxVolume", Mathf.Log10(sliderValue) * 20);
    }
}
