using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    private float _playerSpeedZ;
    private GameManager _gameManager;
    private void Start()
    {
        _playerSpeedZ = GameConfig.Instance.playerSpeedZ;
        _gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (_gameManager.currentGameState==GameState.Playing)
        {
            transform.DOMove(transform.position + Vector3.forward * _playerSpeedZ * Time.deltaTime, 0f);
        }
    }
}
