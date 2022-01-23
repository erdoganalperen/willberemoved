using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StackObject : MonoBehaviour
{
    public Transform followTarget;
    private Vector3 _followOffset;
    private bool _isInitialized;
    private float _followDelay=0;
    public void Initialize(GameObject go,float delay)
    {
        followTarget = go.transform;
        _followOffset = transform.position - followTarget.position;
        _followDelay = delay;
        _isInitialized = true;
    }
    private void Update()
    {
        if (!_isInitialized)
            return;
        transform.DOMove(followTarget.transform.position + _followOffset, _followDelay);
    }
}
