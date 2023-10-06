using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCameraExploring;
    public CinemachineVirtualCamera VirtualCameraFighting;
    public CinemachineVirtualCamera[] virtualCamera;

    
    public GameObject Target = null;
    public GameObject T = null;
    public float speed;
    public bool isExploring = true;

    public PlayerStates playerStates;
    void Start()
    {
        SwitchToCamera(VirtualCameraExploring);
    }

    void Update()

    {


    }

    #region Camera Swiitching
    public void CameraForExploring()
    {
        CinemachineVirtualCamera targetCamera = VirtualCameraExploring;
        SwitchToCamera(targetCamera);
    }

    public void CameraForFighting()
    {
        CinemachineVirtualCamera targetCamera = VirtualCameraFighting;
        SwitchToCamera(targetCamera);
    }

    public void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera camera in virtualCamera)
        {
            camera.enabled = camera == targetCamera;
        }
    }
    #endregion
}
