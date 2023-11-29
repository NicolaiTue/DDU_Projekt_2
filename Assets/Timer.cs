using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviourPunCallbacks
{
    public GameSettings settings;

    public TextMeshProUGUI _text;

    public void SetTimer()
    {
        string text = _text.text;
        
        int timer = 0;
        foreach (char c in text)
        {
            
            if(c <= '9' && c >= '0')
            {
                timer *= 10;
                timer += (int)(0b0000_1111 & (byte)c);
                Debug.Log("byte = " + c);
            }
        }
        Debug.Log("timer = " + timer);
        if (timer < 1)
        {
            timer = 120;
        }
        Debug.Log("timer = " + timer);
        photonView.RPC("CallRPCTimer", RpcTarget.AllBuffered, timer);
        settings.timer = timer;


       
    }

    [PunRPC]
    public void CallRPCTimer(int i)
    {
        Debug.Log("Modtaget parameter: " + i);
        if (!PhotonNetwork.IsMasterClient)
        {
            settings.timer = i;
            // Gør noget med det modtagne parameter
            
        }
        
    }
}
