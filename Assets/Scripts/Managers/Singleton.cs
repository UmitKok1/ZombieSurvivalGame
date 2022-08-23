using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static object _lock = new object();
    private static T _instance;

    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null) _instance = (T)FindObjectOfType(typeof(T));

                return _instance;
            }
        }
    }


}

// Multi thread sorununu fixlemek icin

//public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
//{
//    private static volatile T instance;

//    public static T Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = FindObjectOfType((typeof(T))) as T;
//            }

//            return instance;
//        }
//    }
//}
