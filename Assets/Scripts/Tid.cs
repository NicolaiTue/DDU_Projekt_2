using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tid : MonoBehaviour
{

    [SerializeField]
    private Question _question;
    public Question Question { get { return _question; } }

    [SerializeField]
    private RundeF�rdig _rundeF�rdig;
    public RundeF�rdig RundeF�rdig { get { return _rundeF�rdig; } }

    public Bekraaft _bekraaft;

    DateTime dt;
    public TextMeshProUGUI _text;
    public float resetTime = 10f;
    private float tid_sek = 10f; // 2 min i sek
    private bool timerOn = true;
    private bool triggered = false;

    public void StopTimer()
    {
        timerOn = false;
    }

    public void ResetTimer()
    {
        tid_sek = resetTime;
        timerOn = true;
        triggered = false;
    }

    private void Awake()
    {
        tid_sek = resetTime;
    }


    void Update()
    {
       
        if (timerOn)
        {
            Timer();
        }
        else if(!triggered)
        {
            _text.text = "";
            triggered = true;
            Question.Hide();
            

        }

    }

    private void Timer()
    {
        // Reduser tiden med Time.deltaTime hver gang
        tid_sek -= Time.deltaTime;

        // tjek om tiden er g�et ud
        if (tid_sek <= 0f)
        {

            Debug.Log("Tid er g�et!");
            timerOn = false;
            RundeF�rdig.Svaret("For langsom til at svare", 100);
            _bekraaft.Hide();
        }
        else
        {
            // Oppdater tekstfeltet med gjenv�rende tid
            _text.text = "Tid tilbage: " + Mathf.Floor(tid_sek / 60).ToString("00") + ":" + (tid_sek % 60).ToString("00");
        }
    }

}
