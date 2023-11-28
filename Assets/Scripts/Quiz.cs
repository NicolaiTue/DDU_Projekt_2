using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public GameSettings settings;

    [SerializeField]
    private Question _question;
    public Question Question { get { return _question; } }

    [SerializeField]
    private RundeF�rdig _rundeF�rdig;
    public RundeF�rdig RundeF�rdig { get { return _rundeF�rdig; } }

    public Kategorier _kategorier;
    public Tid tid;

    public PlayerRanking ranking;

    public void OnClick_NextQuestion()
    {
        
        if (PhotonNetwork.IsMasterClient)
        {
            settings.runder--;
            if(settings.runder < 1)
            {
                PhotonNetwork.LoadLevel(3);
                return;
            }
            RundeF�rdig.Hide();
            Question.Show();
            tid.ResetTimer();
            ranking.GetScore();
            _kategorier.MasterChangeScene();
        }

    }
}
