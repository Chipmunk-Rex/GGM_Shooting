using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffectFeedback : Feedback
{
    [SerializeField] private string effectName;
    public override void PlayFeedback()
    {
        EffectPlayer effectPlayer = PoolManager.Instance.Pop(effectName) as EffectPlayer;
        effectPlayer.SetPositionAndPlay(transform.position);
    }

    public override void StopFeedback()
    {
    }
}
