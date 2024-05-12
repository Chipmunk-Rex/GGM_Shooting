using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private CharDataListSo _charList;
    [SerializeField] private Gun _gunPrefab;

    public NotifyValue<Gun> currentGun;
    private Transform _playerTrm;
    private InputReader _playerInput;
    private List<Gun> _gunList;
    private bool _isFire;
    public void Innitialize(Player player)
    {
        _playerTrm = player.transform;
        _playerInput = player.PlayerInput;
        currentGun = new NotifyValue<Gun>();
        currentGun.OnvalueChanged += HandleGunChanged;
        

        MakeWeaponList();
        currentGun.Value = _gunList[0]; //�����Ұ���

        _playerInput.OnCharacterChangeEvent += ChangeGun;
        _playerInput.OnFireKeyEvent += HandleFireKeyEvent;
    }
    private void OnDestroy() {
        _playerInput.OnCharacterChangeEvent -= ChangeGun;
        _playerInput.OnFireKeyEvent -= HandleFireKeyEvent;
    }

    private void HandleFireKeyEvent(bool isFire)
    {
        this._isFire = isFire;
    }

    private void ChangeGun(int a){
        currentGun.Value = _gunList[a];
    }

    private void MakeWeaponList()
    {
        _gunList = new List<Gun>(_charList.dataList.Count);
        foreach(Character ch in _charList.dataList)
        {
            Gun gun = Instantiate(_gunPrefab, transform);
            gun.Initialize(ch.gun);
            gun.gameObject.SetActive(false);
            _gunList.Add(gun);
        }
    }

    private void HandleGunChanged(Gun prev, Gun next)
    {
        if(prev != null)
        {
            prev.gameObject.SetActive(false);
        }
        if(next != null)
        {
            next.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        RotateGun();
        ShootingLogic();
    }

    private void ShootingLogic()
    {
        if (_isFire && currentGun.Value != null)
        {
            currentGun.Value.TryToShoot();
        }
    }

    private void RotateGun(){
        Vector3 mousePos = _playerInput.MousePosition;
        Vector2 direction = _playerTrm.InverseTransformPoint(mousePos);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0,0,angle);
    }
}
