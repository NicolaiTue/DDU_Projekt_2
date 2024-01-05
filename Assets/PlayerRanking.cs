using System.Collections;
using System.Collections.Generic;
using TMPro;
using Photon.Pun;
using UnityEngine;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Linq;

public class PlayerRanking : MonoBehaviour
{
    public TextMeshProUGUI _text;

    public void GetScore()
    {
        _text.text = PhotonNetwork.LocalPlayer.NickName + ": " + PhotonNetwork.LocalPlayer.GetScore() + "\n\n";
        List<Player> playerlist = PhotonNetwork.PlayerList.ToList();
        playerlist.Sort((x,y)=> x.GetScore().CompareTo(y.GetScore()));
        foreach (Player player in playerlist)
        {
            Debug.Log(player.GetScore() + player.NickName);
            _text.text += player.NickName + ": " + player.GetScore() + "\n";
        }
    }
}
