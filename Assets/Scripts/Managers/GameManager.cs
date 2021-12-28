using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    [Header("Camera Settings")]
    [SerializeField] private List<VirtualCameraProperties> virtualCameras;
    [Header("Other")]
    public GameState CurrentGameState;
    public Action<GameState> ONGameStateChange;

    protected override void OnAwake()
    {
        CurrentGameState = GameState.Start;
    }

    public void ChangeState(GameState state)
    {
        CurrentGameState = state;
        ONGameStateChange?.Invoke(state);
        if (state==GameState.Playing)
        {
            SetActiveVirtualCamera(virtualCameras[0]);
        }
        else if (state == GameState.Scoring)
        {
            SetActiveVirtualCamera(virtualCameras[1]);
            Scoring();
        }

    }
    void SetActiveVirtualCamera(VirtualCameraProperties cam)
    {
        foreach (var camera in virtualCameras)
        {
            if (camera.VCam==cam.VCam)
            {
                camera.VCam.gameObject.SetActive(true);
            }
            else
            {
                camera.VCam.gameObject.SetActive(false);
            }
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
