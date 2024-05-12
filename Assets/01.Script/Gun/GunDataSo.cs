using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SO/Gun/GunData")]
public class GunDataSo : ScriptableObject
{
    public Sprite gunSprite;
    public string gunName;
    public Vector3 spritePosition;
    public Vector3 fireTrmPosition;

    public int damage;
    public int maxAmmo;
    public float reloadTime;
    public float cooldown;

    public float knockBackPower;
    public Projectile bulletPrefab;
    public float _impulsePower;
}
