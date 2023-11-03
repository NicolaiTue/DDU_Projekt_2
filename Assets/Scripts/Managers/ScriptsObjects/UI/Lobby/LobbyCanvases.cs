using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCanvases : MonoBehaviour
{
    [SerializeField]
    private CanvasLobby _canvasLobby;
    public CanvasLobby CanvasLobby {  get { return _canvasLobby; } }

    [SerializeField]
    private NuværendeLobbyCanvas _nuværendeLobbyCanvas;
    public NuværendeLobbyCanvas NuværendeLobbyCanvas { get { return _nuværendeLobbyCanvas; } }

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        CanvasLobby.FirstInitialize(this);
        NuværendeLobbyCanvas.FirstInitialize(this);
    }
}
