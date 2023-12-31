using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public Player Player { get; private set; }

    public void SetPlayerInfo(Player player)
    {
        Player = player;
        _text.text = player.NickName;
    }


}
