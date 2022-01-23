using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    public PlayerParent playerParent;
    [Header("Child Components")] 
    [SerializeField] private PlayerMovementController playerMovementController;
    private Vector3 _restartPos;
    private void Awake()
    {
        _restartPos = transform.position;
    }
    void Start()
    {
        GameManager.Instance.ONGameStateChange += OnGameStateChangeState;
        LevelManager.Instance.ONLevelLoaded += OnLevelLoaded;
    }
    private void OnLevelLoaded()
    {
        transform.position = _restartPos;
    }

    void OnGameStateChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                playerMovementController.StopMovement();
                break;
            case GameState.Playing:
                playerMovementController.ContinueMovement();
                break;
            case GameState.Scoring:
                playerMovementController.StopMovement();
                break;
            case GameState.Finish:
                
                break;
        }
    }
}
