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
    private RundeF�rdig _rundeF�rdig;
    public RundeF�rdig RundeF�rdig { get { return _rundeF�rdig; } }

    public void OnClick_NextQuestion()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Question.Hide();
            RundeF�rdig.Show();
        }

    }
}
