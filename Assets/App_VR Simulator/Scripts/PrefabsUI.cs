using UnityEngine;

[CreateAssetMenu(fileName = "PrefabsUI", menuName = "Scriptable Objects/PrefabsUI")]
public class PrefabsUI : ScriptableObject {
    [SerializeField] private MenuLobbyView prefabMenuLobby;
    [SerializeField] private MenuGameView prefabMenuGame;
    [SerializeField] private PanelGroup prefabPanelGroup;
    [SerializeField] private ItemStep prefabItemStep;
    [SerializeField] private PanelStatistics prefabPanelStatistics;
    [SerializeField] private NameGroup prefabNameGroup;
    
    public MenuLobbyView PrefabMenuLobby => prefabMenuLobby;
    public MenuGameView PrefabMenuGame => prefabMenuGame;
    public PanelGroup PrefabPanelGroup => prefabPanelGroup;
    public ItemStep PrefabItemStep => prefabItemStep;
    public PanelStatistics PrefabPanelStatistics => prefabPanelStatistics;
    public NameGroup PrefabNameGroup => prefabNameGroup;
    
}
