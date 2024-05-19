using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    // [Header("Settings")]
    // [SerializeField] private float _extraGravity = 30f, _gravityDelay = 0.15f;

    #region Component Regeion
    public AgentMovement MovementCompo { get; protected set;}
    public Animator AnimatorCompo { get; protected set;}
    public Health HealthCompo{ get; protected set;}
    #endregion

    public bool IsDead{get; protected set;}
    protected float _timeInAir;
    protected virtual void Awake() {
        MovementCompo = GetComponent<AgentMovement>();
        MovementCompo.Initialize(this);
        
        AnimatorCompo = transform.Find("Visual").GetComponent<Animator>();

        HealthCompo = GetComponent<Health>();
        HealthCompo.Initialize(this);
    }
    #region Flip Character
    public bool IsFacingRight()
    {
        return Mathf.Approximately(transform.eulerAngles.y,0);

    }
    public void HandleSpriteFlip(Vector3 targerPosition)
    {
        if(targerPosition.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
        }else if (targerPosition.x > transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    #endregion

}
