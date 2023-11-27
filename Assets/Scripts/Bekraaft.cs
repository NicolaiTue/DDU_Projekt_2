using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bekraaft : MonoBehaviour
{

    public RundeFærdig rundeFærdig;
    public Tid tid;
    public int points {private get; set; }
    public string svar { private get; set; }


    public void GivePoints()
    {
        tid.StopTimer();
        Hide();
        rundeFærdig.Svaret(svar, points);
        
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
