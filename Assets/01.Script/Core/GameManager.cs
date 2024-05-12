using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Pool _bulletPool;
    [SerializeField] private Bullet _bullet;
    private void Awake() {
        _bulletPool = new Pool(_bullet, transform, 15);
    }
    public Bullet Pop(){
        Bullet bullet = _bulletPool.Pop() as Bullet;
        bullet.ResetItem();
        return bullet;
    }
    public void Push(Bullet bullet){
        _bulletPool.Push(bullet);
    }
}