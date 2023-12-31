using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manger/GameSettings")]

public class GameSettings : ScriptableObject
{

    public int runder = 1;
    public int timer = 1;

    [SerializeField]
    private string _gameVersion = "0.0.0";
    public string GameVersion { get { return _gameVersion; } }



    public string _nickName = "Tue";



    public string NickName
    {
        get
        {
            int value = Random.Range(0, 9999);
            return _nickName + value.ToString();
        }
    } 


}
