using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "AudioResources", menuName = "Scriptable Objects/AudioResources")]
public class AudioResources : ScriptableObject {
    [SerializeField] private AudioClip clipCorrect;
    [SerializeField] private AudioClip clipInCorrect;
    
    public AudioClip ClipCorrect => clipCorrect;
    public AudioClip ClipInCorrect => clipInCorrect;

}
