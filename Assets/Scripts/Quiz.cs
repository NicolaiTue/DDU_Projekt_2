using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{

    [SerializeField]
    private Question _question;
    public Question Question { get { return _question; } }

    [SerializeField]
    private RundeFærdig _rundeFærdig;
    public RundeFærdig RundeFærdig { get { return _rundeFærdig; } }

    public void OnClick_NextQuestion()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Question.Hide();
            RundeFærdig.Show();
        }

    }
}
