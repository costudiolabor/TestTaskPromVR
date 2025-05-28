using UnityEngine;
using System;

[Serializable]
public class SoundHandler {
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipCorrect;
    [SerializeField] private AudioClip clipWrong;
    
    public void PlayCorrect() {
        audioSource.PlayOneShot(clipCorrect);
    }

    public void PlayInCorrect() {
        audioSource.PlayOneShot(clipWrong);
    }
    
 }
