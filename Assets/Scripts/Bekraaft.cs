using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bekraaft : MonoBehaviour
{

    public RundeF�rdig rundeF�rdig;
    public Tid tid;
    public int points {private get; set; }
    public string svar { private get; set; }


    public void GivePoints()
    {
        tid.StopTimer();
        Hide();
        rundeF�rdig.Svaret(svar, points);
        
    }


    public void Show()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }




}
