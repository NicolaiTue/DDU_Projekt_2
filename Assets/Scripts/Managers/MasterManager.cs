using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singelton/MasterManager")]
public class MasterManager : ScriptableObjectSingelton<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;
    public static GameSettings gameSettings { get { return Instance._gameSettings; } }


}
