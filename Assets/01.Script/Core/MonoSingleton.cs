using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instace = null;
    private static bool IsDestroyed = false;
    public static T Instance{
        get{
            if(IsDestroyed)
                _instace = null;
            if(_instace == null){
                    _instace = GameObject.FindAnyObjectByType<T>();
                if(_instace == null)
                    throw new Exception("바보같은! 싱글톤이 없어!");
                else
                IsDestroyed = false;
            }
                return _instace;
        }
    }

    private void OnDisable(){
        IsDestroyed = true;
    }
}
