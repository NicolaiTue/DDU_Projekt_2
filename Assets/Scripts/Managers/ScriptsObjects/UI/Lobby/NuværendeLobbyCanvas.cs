using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuværendeLobbyCanvas : MonoBehaviour
{
    private LobbyCanvases _lobbyCanvases;

    [SerializeField]
    private PlayerList _playerList;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;

    public void FirstInitialize(LobbyCanvases canvases)
    {
        _lobbyCanvases = canvases;
        _playerList.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInttialize(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
