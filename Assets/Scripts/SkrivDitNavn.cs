using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkrivDitNavn : MonoBehaviour
{
    public GameSettings settings;
    public TextMeshProUGUI _text;

    public void SetName()
    {
        settings._nickName = _text.text;
    }

}
