using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetWorkManeger : MonoBehaviourPunCallbacks
{
    public Kategorier kategorier;


    [PunRPC]
     void MyRPCFunction(int parameter)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            kategorier.ChangeScreen(parameter);
            // Gør noget med det modtagne parameter
            Debug.Log("Modtaget parameter: " + parameter);
        }
            
    }
}
