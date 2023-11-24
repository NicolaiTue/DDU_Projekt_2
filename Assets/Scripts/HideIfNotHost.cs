using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfNotHost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
