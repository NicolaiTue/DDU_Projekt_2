using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class LobbyListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        _text.text = roomInfo.MaxPlayers + ","+roomInfo.Name;
    }

    public void OnClickButton()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }

}
