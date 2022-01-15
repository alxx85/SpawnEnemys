using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _endPoint;
    private float _rotateDelay = 0.5f;
    private Vector3 _forward = new Vector3(0, 180, 0);
    private Vector3 _back = new Vector3(0, 0, 0);

    public void SetEndPoint(Vector3 position)
    {
        _endPoint = position;
        StartMoving();
    }

    private void StartMoving()
    {
        float delay = Vector3.Distance(Vector3.zero, _endPoint) / _speed;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(_forward, 0));

        sequence.Append(transform.DOMove(_endPoint, delay).SetEase(Ease.Linear).SetDelay(_rotateDelay));

        sequence.Append(transform.DORotate(_back, 0).SetDelay(_rotateDelay));
        sequence.SetLoops(-1, LoopType.Yoyo);
    }

}
