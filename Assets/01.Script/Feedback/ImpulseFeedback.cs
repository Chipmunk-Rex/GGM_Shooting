using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
[RequireComponent(typeof(CinemachineImpulseSource))]
public class ImpulseFeedback : Feedback
{
    [SerializeField] public Gun gun;
    [SerializeField] private float _impulsePower = 0.3f;
    private CinemachineImpulseSource _source;
    private void Awake() {
        _source = GetComponent<CinemachineImpulseSource>();
    }
    public override void PlayFeedback()
    {
        if(gun != null)
            _source.GenerateImpulse(gun.gunData._impulsePower);
        else
            _source.GenerateImpulse(_impulsePower);

    }

    public override void StopFeedback()
    {
    }
}
