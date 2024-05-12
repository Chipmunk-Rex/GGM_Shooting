using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTween : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Tween _tween;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);

            Sequence seq = DOTween.Sequence();

            seq.Append(transform.DOMove(new Vector3(x, y), 1f));
            seq.Join(transform.DORotate(new Vector3(0,0,360f), 0.3f,RotateMode.FastBeyond360));
            seq.Append(transform.DOShakePosition(0.3f,0.2f));
            seq.AppendCallback(() => { Debug.Log("³¡"); }) ;


            //transform.position = new Vector3(x, y);

            _tween = transform.DOMove(new Vector3(x, y),1f);
        }
        if(Input.GetKeyDown(KeyCode.S)) {
            if(_tween != null && _tween.IsActive())
            _tween.Kill();
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            _tween.Complete();
        }
    }
}
