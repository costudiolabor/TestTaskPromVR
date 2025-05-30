using UnityEngine;

[CreateAssetMenu(fileName = "Prefabs", menuName = "Scriptable Objects/Prefabs")]
public class Prefabs : ScriptableObject { 
    [SerializeField] private Player player;
    
    public Player Player => player;
    
}
