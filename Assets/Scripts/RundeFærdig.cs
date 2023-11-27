using System.Collections;
using System.Collections.Generic;
using TMPro;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using Photon.Realtime;
using System.Linq;

public class RundeFærdig : MonoBehaviour
{
    public TextMeshProUGUI _text;
    public TextMeshProUGUI _points;
    private List<Player> _playerList;
    public int delay = 5;

    
    public void Svaret(string answer , int i)
    {
        _text.text = answer;
        _points.text = ""+i;
        int curentPoint = PhotonNetwork.LocalPlayer.GetScore();
        PhotonNetwork.LocalPlayer.SetScore(curentPoint + i);

        Show();
        SeePoints();
    }

    private void SeePoints()
    {
        waiter();
        Player[] playerlist = PhotonNetwork.PlayerList;
        foreach(Player player in playerlist)
        {
            Debug.Log(player.GetScore() + player.NickName);
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(delay);
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
