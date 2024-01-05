using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class Runder : MonoBehaviour
{
   
    public GameSettings settings;

    public TextMeshProUGUI _text;


    public void SetRunder()
    {
       
        

        string text = _text.text;
        Debug.Log(text);
        int runder = 0;
        foreach (char c in text)
        {
            
            if ( c<='9' && c >= '0')
            {
                runder *= 10;
                Debug.Log("char" + c);
                Debug.Log("runde byte " + (int)(0b0000_1111 & (byte)c));
                runder = (int)(0b0000_1111 & (byte)c) + runder;
            }
        }
        if(runder < 1)
        {
            runder = 20;
        }

        Debug.Log("runder = " + runder);
        settings.runder = runder;
        

        //if ()
        //{
        //    settings.runder = Convert.ToInt32(text);
        //}
        //else
        //{
        //    Debug.Log($"Attempted conversion of {text} failed");
        //}

    }
}
