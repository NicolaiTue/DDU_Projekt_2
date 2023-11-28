using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameSettings settings;

    public TextMeshProUGUI _text;

    public void SetTimer()
    {
        string text = _text.text;
        
        int timer = 0;
        foreach (char c in text)
        {
            
            if(c <= '9' && c >= '0')
            {
                timer *= 10;
                timer += (int)(0b0000_1111 & (byte)c);
            }
        }
        Debug.Log("timer = " + timer);
        settings.timer = timer;

    }
}
