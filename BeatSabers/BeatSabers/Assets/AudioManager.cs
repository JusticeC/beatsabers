﻿//using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {


    public Sounds[] sounds;
    public string musicName;
    public AudioHelm.AudioHelmClock clock;

    // Use this for initialization
    void Awake () {
        clock = FindObjectOfType<AudioHelm.AudioHelmClock>();
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
	}

    private void Start()
    {
        Invoke("PlayMusic", 240f/clock.bpm);
    }

    public void PlayMusic()
    {
        musicName = "Theme";
        Sounds s = Array.Find(sounds, Sounds => Sounds.name == musicName);
        s.source.Play();
    }

    public void Play (string name)
    {
        Sounds s = Array.Find(sounds, Sounds => Sounds.name == name);
        s.source.Play();
    }
}
