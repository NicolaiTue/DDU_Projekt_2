using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectSingelton<T> :ScriptableObject where T : ScriptableObject
{
   private static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                if (results.Length == 0)
                {
                    Debug.LogError("ScriptableObjectSingelton -> Instance -> results length is 0 for type" + typeof(T).ToString() + ".");
                }
                if (results.Length > 1)
                {
                    Debug.LogError("ScriptableObjectSingelton -> Instance -> results length is greather then 1 for type" + typeof(T).ToString() + ".");
                }

                _instance = results[0];

            }
            return _instance;
        }
    }


}
