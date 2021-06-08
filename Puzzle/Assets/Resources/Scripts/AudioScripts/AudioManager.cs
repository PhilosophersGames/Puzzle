using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned AudioManager", typeof(AudioManager)).GetComponent<AudioManager>();
                }
            }
            return (instance);
        }
        private set
        {
            instance = value;
        }
    }


    // Init var
    AudioMixer audioMixer;
    AudioMixerGroup[] audioMixGroup;


    // Init AudioSources
    private AudioSource musicSource;
    private AudioSource musicSource2;
    private AudioSource sfxSource;


    private bool firstMusicSourceIsPlaying = true;

    private void Awake()
    {
       audioMixer = Resources.Load<AudioMixer>("Sound/Mixer/Master");

        DontDestroyOnLoad(this.gameObject);


        // Initialize Music Source, 2 seems enough for the moment
        musicSource = this.gameObject.AddComponent<AudioSource>();
        musicSource2 = this.gameObject.AddComponent<AudioSource>();

        // Initialize SFX Source
        sfxSource = this.gameObject.AddComponent<AudioSource>();


        // Initialize Master as the AudioGroup
        audioMixGroup = audioMixer.FindMatchingGroups("Master");


        // Initialize Outputs to the right mixers 
        musicSource.outputAudioMixerGroup = audioMixGroup[2];
        musicSource2.outputAudioMixerGroup = audioMixGroup[2];
        sfxSource.outputAudioMixerGroup = audioMixGroup[1];

        //loop music
        musicSource.loop = true;
        musicSource2.loop = true;
    }


    // Usable Functions to call Sounds


     // Will play music, and prevent 2 sources from overlapping, by playing the last called
    public void PlayMusic(AudioClip musicClip)
    {
    
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;
        
        activeSource.clip = musicClip;
        activeSource.Play();
    }


    // Play music at a specific moment of it
    public void PlayMusicAtTime(AudioClip musicClip, float timestamp) 
    {
        AudioSource activeSource = musicSource;//(firstMusicSourceIsPlaying) ? musicSource : musicSource2;

        activeSource.clip = musicClip;

        activeSource.timeSamples = (int)(timestamp * musicClip.frequency);
        activeSource.Play();
    }


    //Simple Play OneShot function
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }


    //Simple play OneShot Function with a specific volume
    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    // Play Music with a Fade Transition so it's smoother
    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
    {
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;
        StartCoroutine(UpdateMusicWithFade(activeSource, newClip, transitionTime));

    }

    //Coroutine part of PlayMusicWithFade function
    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip , float transitionTime)
        {
        if (!activeSource.isPlaying)
            activeSource.Play();
        float t = 0.0f;
        //fade out
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (1 - (t / transitionTime));
            yield return null;
        }

        activeSource.Stop();
        activeSource.clip = newClip;
        activeSource.Play();
        //fade in
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (t / transitionTime);
            yield return null;
        }
    }

    // Set Volume to the ActiveSource
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicSource2.volume = volume;
    }


    //Set SFX volume
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
