using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class CreateLobby : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI _roomName; 

    public void OnClick_CreatRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        RoomOptions options = new RoomOptions();
        options.EmptyRoomTtl = 10000;
        options.MaxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);

    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created lobby succesfully", this);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Lobby creation failed:" + message, this);
    }

}
