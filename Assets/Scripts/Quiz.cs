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
    private RundeFærdig _rundeFærdig;
    public RundeFærdig RundeFærdig { get { return _rundeFærdig; } }

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
            RundeFærdig.Hide();
            Question.Show();
            tid.ResetTimer();
            ranking.GetScore();
            _kategorier.MasterChangeScene();
        }

    }
}
