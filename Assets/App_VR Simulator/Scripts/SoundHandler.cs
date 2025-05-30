using UnityEngine;
using System;

[Serializable]
public class SoundHandler {
    private AudioClip _clipCorrect;
    private AudioClip _clipWrong;
    private AudioSource _audioSource;

    public SoundHandler(AudioSource audioSource, AudioResources audioResources) {
        _audioSource = audioSource;
        _clipCorrect = audioResources.ClipCorrect;
        _clipWrong = audioResources.ClipInCorrect;
    }

    public void PlayCorrect() {
        _audioSource.PlayOneShot(_clipCorrect);
    }

    public void PlayInCorrect() {
        _audioSource.PlayOneShot(_clipWrong);
    }
    
 }
