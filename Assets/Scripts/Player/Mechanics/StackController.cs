using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class StackController : MonoBehaviour
{
    private float _stackOffset;
    public GameObject stackObject;
    public StackType stackType;
    private Stack<GameObject> _stackedObjects;
    public GameObject followGameObject;
    public float followDelay;
    private Vector3 _followOffset;
    private void Awake()
    {
        _stackedObjects = new Stack<GameObject>();
    }

    void Start()
    {
        switch (stackType)
        {
            case StackType.Forward:
                _stackOffset = stackObject.transform.localScale.y;
                break;
            case StackType.Up:
                _stackOffset = stackObject.transform.localScale.z;
                break;
        }
        _followOffset=transform.position-followGameObject.transform.position;
    }

    private void Update()
    {
        transform.DOMove(followGameObject.transform.position+_followOffset, followDelay);
    }

    [Button("Add to Stack",EButtonEnableMode.Playmode)]
    public void AddToStack()
    {
        var obj = Instantiate(stackObject, transform);
        switch (stackType)
        {
            case StackType.Up:
                obj.transform.localPosition = new Vector3(0, _stackedObjects.Count * _stackOffset,0);
                break;
            case StackType.Down:
                break;
            case StackType.Forward:
                obj.transform.localPosition = new Vector3(0, 0, _stackedObjects.Count * _stackOffset);
                break;
        }

        obj.GetComponent<StackObject>().Initialize(_stackedObjects.Count == 0 ? gameObject : _stackedObjects.Peek(),followDelay);
        _stackedObjects.Push(obj);

    }
    [Button("Remove to Stack",EButtonEnableMode.Playmode)]
    public void RemoveFromStack()
    {
        Destroy(_stackedObjects.Pop().gameObject);
    }
}
