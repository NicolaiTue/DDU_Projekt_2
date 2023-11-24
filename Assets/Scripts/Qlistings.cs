using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Qlistings : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    public string answerTxt = "";
    public int answerPoint = 0;

    

    public Kategorier _kategorier;

    int x = _;

    public void SetupBtn(string text, int value)
    {
        answerTxt = text;
        answerPoint = value;
        _text.text = answerTxt;
    }

    public void Selected()
    {
        //send svar og opdater min score
    }

    public void SetMuligheder(Kategorier muligheder)
    {
        _text.text = muligheder.ToString();
    }
}
