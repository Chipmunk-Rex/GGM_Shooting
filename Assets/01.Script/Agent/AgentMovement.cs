using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{

    [Header("Reference")]
    [SerializeField] private Transform _groundCheckerTrm;
    [Header("Settings")]
    public float moveSpeed = 5f;
    public float jumpPower = 7f;
    public float extraGravity = 30f;
    public float gravityDelay = 0.15f;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Vector2 _groundCheckerSize;
    public Rigidbody2D rbCompo {  get; private set; }
    public NotifyValue<bool> isGround = new NotifyValue<bool>();
    protected float _xMove;
    private float _timeInAir;
    private void Awake()
    {
        rbCompo = GetComponent<Rigidbody2D>();
    }
    public void SetMovement(float xMove)
    {
        _xMove = xMove;
    }
    public void StopImmediately(bool isYStop = true)
    {
        _xMove = 0;
        if(isYStop) {
            rbCompo.velocity = Vector2.zero;
        }
        else
        {
            rbCompo.velocity = new Vector2(_xMove,rbCompo.velocity.y);
        }
    }
    public void Jump(float multiplier = 1f)
    {
        _timeInAir = 0;
        rbCompo.velocity = Vector2.zero;
        rbCompo.AddForce(Vector2.up * jumpPower *  multiplier, ForceMode2D.Impulse);
    }
    private void Update()
    {
        if (!isGround.Value)
        {
            _timeInAir += Time.deltaTime;
        }
        else
        {
            _timeInAir=0;
        }
        
    }
    private void FixedUpdate()
    {
        isGround.Value = CheckGrounded();
        rbCompo.velocity = new Vector2(_xMove * moveSpeed, rbCompo.velocity.y);
        ApplyExtraGravity();
    }
    public bool CheckGrounded()
    {
        Collider2D collider = Physics2D.OverlapBox(_groundCheckerTrm.position, _groundCheckerSize, 0, _whatIsGround);
        return collider;
    }
    private void ApplyExtraGravity()
    {
        if (_timeInAir > gravityDelay)
            rbCompo.AddForce(new Vector2(0, -extraGravity));
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (_groundCheckerTrm == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundCheckerTrm.position, _groundCheckerSize);
        Gizmos.color = Color.white;
    }
#endif
}
