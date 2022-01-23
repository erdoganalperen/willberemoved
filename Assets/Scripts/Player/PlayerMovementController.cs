using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private bool _canMove;
    private float _clampValueX;
    private float _playerSpeedX;
    private Vector3 _targetLocalPosition;
    private void Awake()
    {
        _canMove = false;
    }
    void Start()
    {
        _clampValueX = GameConfig.Instance.clampX;
        _playerSpeedX = GameConfig.Instance.playerSpeedX;
        _targetLocalPosition = transform.localPosition;
    }
    void Update()
    {
        if (_canMove)
        {
            PlayerInput();
            Clamp();
            Move();
        }
    }

    void PlayerInput()
    {
        //player child object local position
        if (Input.GetMouseButton(0))
        {
            float direction = 0;
            
            if (Input.GetAxis("Mouse X") > 0)
                direction = 1;
            if (Input.GetAxis("Mouse X") < 0)
                direction = -1;

            _targetLocalPosition.x += _playerSpeedX * Time.deltaTime * direction;
        }
    }

    void Clamp()
    {
        _targetLocalPosition.x = Mathf.Clamp(_targetLocalPosition.x, -_clampValueX, _clampValueX);
    }

    void Move()
    {
        transform.DOLocalMove(_targetLocalPosition, 0f);
    }

    public void StopMovement()
    {
        _canMove = false;
    }

    public void ContinueMovement()
    {
        _canMove = true;
    }
}
