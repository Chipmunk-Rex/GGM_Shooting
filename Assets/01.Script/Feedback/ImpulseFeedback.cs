using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
[RequireComponent(typeof(CinemachineImpulseSource))]
public class ImpulseFeedback : Feedback
{
    [SerializeField] public Gun gun;
    private CinemachineImpulseSource _source;
    private void Awake() {
        _source = GetComponent<CinemachineImpulseSource>();
    }
    public override void PlayFeedback()
    {
        _source.GenerateImpulse(gun.gunData._impulsePower);
    }

    public override void StopFeedback()
    {
    }
}
