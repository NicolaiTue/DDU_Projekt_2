using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLobby : MonoBehaviour
{
    [SerializeField]
    private CreateLobby _createLobby;
    [SerializeField]
    private LobbyList _lobbyList;

    private LobbyCanvases _lobbyCanvases; 

    public void FirstInitialize(LobbyCanvases canvases)
    {
        _lobbyCanvases = canvases;
        _createLobby.FirstInitialize(canvases);
        _lobbyList.FirstInitialize(canvases);
    }
}
