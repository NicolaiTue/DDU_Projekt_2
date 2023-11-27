using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Qlistings : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    public string answerTxt = "";
    public int answerPoint = 0;
    private Bekraaft _bekraaft;

    public void SetupBtn(string text, int value)
    {
        answerTxt = text;
        answerPoint = value;
        _text.text = answerTxt;
    }

    private void Awake()
    {
        _bekraaft = GameObject.FindObjectOfType(typeof(Bekraaft)).GetComponent<Bekraaft>();

    }

    public void OnClick()
    {
        _bekraaft.Show();
        _bekraaft.points = answerPoint;
        _bekraaft.svar = answerTxt;
    }

    public void SetMuligheder(Kategorier muligheder)
    {
        _text.text = muligheder.ToString();
    }
}
