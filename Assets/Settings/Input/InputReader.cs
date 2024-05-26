using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    private Controls _controls;
    public Action JumpKeyEvent;
    public Action<bool> OnFireKeyEvent;
    public Action ReloadKeyEvent;
    public Vector2 MousePosition {  get; private set; }
    public Vector2 Movement {  get; private set; }
    public event Action<int> OnCharacterChangeEvent;

    private void OnEnable()
    {
        if(_controls == null)
        {
            _controls = new Controls();
        }
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();//Normalize�ڵ����� ����
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            JumpKeyEvent?.Invoke();
        }
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        Vector2 pos = context.ReadValue<Vector2>();//��ũ�� ��ǥ
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
        worldPos.z = 0;
        MousePosition = worldPos;
        
    }

    public void OnChangeOne(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnCharacterChangeEvent?.Invoke(0);
        }
    }

    public void OnChangeTwo(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnCharacterChangeEvent?.Invoke(1);
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnFireKeyEvent?.Invoke(true);
        if(context.canceled)
            OnFireKeyEvent?.Invoke(false);
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if(context.performed)
            ReloadKeyEvent?.Invoke();
    }
}
