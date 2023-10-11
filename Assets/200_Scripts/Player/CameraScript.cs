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

    #region Camera Switching

    // Changing for the Exploring View
    public void CameraForExploring()
    {
        CinemachineVirtualCamera targetCamera = VirtualCameraExploring;
        SwitchToCamera(targetCamera);
    }
    
    // Changing for fighting view
    public void CameraForFighting()
    {
        CinemachineVirtualCamera targetCamera = VirtualCameraFighting;
        SwitchToCamera(targetCamera);
    }

    // Method for switching camera in a list
    public void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera camera in virtualCamera)
        {
            camera.enabled = camera == targetCamera;
        }
    }
    #endregion
}
