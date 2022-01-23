using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : GenericSingleton<CameraManager>
{
    [SerializeField] private List<VirtualCameraProperties> virtualCameras;
    protected override void OnAwake()
    {
       SetActiveVirtualCamera(CameraType.StartCamera);
    }

    private void Start()
    {
        GameManager.Instance.ONGameStateChange += OnGameStateChanged;
    }

    void OnGameStateChanged(GameState state)
    {
        if (state==GameState.Playing)
        {
            SetActiveVirtualCamera(CameraType.PlayingCamera);
        }
        else if (state == GameState.Scoring)
        {
            SetActiveVirtualCamera(CameraType.FinishCamera);
        }
    }
    
    void SetActiveVirtualCamera(CameraType cameraType)
    {
        foreach (var cameraProperties in virtualCameras)
        {
            cameraProperties.vCam.gameObject.SetActive(cameraProperties.cameraType == cameraType);
        }
    }
}
