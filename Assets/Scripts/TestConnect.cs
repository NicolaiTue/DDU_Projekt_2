using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnect : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        print("connecting to server");
        PhotonNetwork.NickName = MasterManager.gameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.gameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        print("connected to server");
        print(PhotonNetwork.LocalPlayer.NickName);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconected from server. Reason" + cause.ToString());
    }




}
