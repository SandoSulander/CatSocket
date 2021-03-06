﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    public AudioMixerGroup mixerGroup;

    // Use this for initialization
    void Awake () {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;
        }


		
	}

    private void Start()
    {
        Play("Theme");  
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        if (PauseMenu.GameIsPaused)
        {
            s.source.volume *= 0.5f;
            s.source.Play();
        }
        else
        {
            s.source.volume *= 1f;
            s.source.Play();
        }

    }
		
}
