using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCanvases : MonoBehaviour
{
    [SerializeField]
    private CanvasLobby _canvasLobby;
    public CanvasLobby CanvasLobby {  get { return _canvasLobby; } }

    [SerializeField]
    private Nuv�rendeLobbyCanvas _nuv�rendeLobbyCanvas;
    public Nuv�rendeLobbyCanvas Nuv�rendeLobbyCanvas { get { return _nuv�rendeLobbyCanvas; } }

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        CanvasLobby.FirstInitialize(this);
        Nuv�rendeLobbyCanvas.FirstInitialize(this);
    }
}
