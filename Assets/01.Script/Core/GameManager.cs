using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private Portal _portalPrefab;
    private void Update() {
        if(Keyboard.current.pKey.wasPressedThisFrame)
        {
            Vector3 pos = new Vector3(8,2);
            Portal p = Instantiate(_portalPrefab, pos, Quaternion.identity);

            p.OpenPortal(pos);
        //    ZombieToast enemy = PoolManager.Instance.Pop("ZombieEnemy") as ZombieToast;
        //    enemy.transform.position = new Vector3(0,5,0);
        }
    }
}