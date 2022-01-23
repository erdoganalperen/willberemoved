using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : GenericSingleton<GameManager>
{
    [Header("Camera Settings")]
    [HideInInspector] public GameState currentGameState;
    public Action<GameState> ONGameStateChange;

    protected override void OnAwake()
    {
        currentGameState = GameState.Start;
    }

    public void ChangeState(GameState state)
    {
        currentGameState = state;
        ONGameStateChange?.Invoke(state);
        if (state==GameState.Playing)
        {
        }
        else if (state == GameState.Scoring)
        {
            Scoring();
        }
    }
    void Scoring()
    {
        StartCoroutine(ScoringCoroutine());
    }
    IEnumerator ScoringCoroutine()
    {
        yield return new WaitForSeconds(3);
        ChangeState(GameState.Finish);
    }
}
