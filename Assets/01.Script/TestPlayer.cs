using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer : MonoBehaviour
{
    private Controls _controls;
    private Rigidbody2D _rigid;
    Vector2 movement;
    private void Awake() {
        _rigid = GetComponent<Rigidbody2D>();
        _controls = new Controls();

        _controls.Enable();
        _controls.Player.Jump.performed += OnJump;
        _controls.Player.Jump.canceled += OnJump;
    }

    private void MovePreform(){
        movement = _controls.Player.Movement.ReadValue<Vector2>();
    }
    private void Update() {
        MovePreform();
        if(Keyboard.current.oKey.wasPressedThisFrame){
            _controls.Player.Disable();
            _controls.Player.Jump.PerformInteractiveRebinding().WithControlsExcluding("mouse").OnComplete(op => 
            {
                Debug.Log(op);
                op.Dispose();
                _controls.Player.Enable();
            }
            ).Start();
        }
    }
    private void FixedUpdate() {
        _rigid.velocity = movement * 7;
    }
    public void OnJump(InputAction.CallbackContext context){
        Debug.Log(context);
    }
}
