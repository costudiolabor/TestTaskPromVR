using System;
using UnityEngine;

[Serializable]
public class PlayerHandler {
    private Player _player;
    
    public Player GetPlayer(Factory factory, Player player) {
        _player = factory.Get(player, null);
        return _player;
    }
    
    public Transform GetCamera() {
        return _player.CameraTransform;
    }

}
