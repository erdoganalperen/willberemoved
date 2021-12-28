using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _targetPos;
    private Vector3 _restartPos;
    private float _speed;
    private float _clampX;
    private bool _canMove;
    private void Awake()
    {
        _canMove = false;
        _restartPos = transform.position;
        _targetPos = _restartPos;
        
    }
    void Start()
    {
        _speed = GameConfig.Instance.PlayerSpeed;
        _clampX = GameConfig.Instance.ClampX;
        GameManager.Instance.ONGameStateChange += PlayerChangeState;
        LevelManager.Instance.ONLevelLoaded += OnLevelLoaded;
    }
    private void OnLevelLoaded()
    {
        _targetPos = _restartPos;
        transform.position = _restartPos;
    }
    void Update()
    {
        if (_canMove)
        {
            GetInput();
            Move();
        }
    }
    void PlayerChangeState(GameState state)
    {
        if (state == GameState.Playing)
        {
            _canMove = true;
        }
        if (state == GameState.Scoring || state==GameState.Finish)
        {
            _canMove = false;
        }
    }
    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            _targetPos.x += Input.GetAxis("Mouse X") * _speed;
            _targetPos.x = Mathf.Clamp(_targetPos.x, -_clampX, _clampX);
        }
        _targetPos.z += Time.deltaTime * _speed;
    }
    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPos, Time.deltaTime * 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FinishController>() != null)
        {
            GameManager.Instance.ChangeState(GameState.Scoring);
        }
    }
}
