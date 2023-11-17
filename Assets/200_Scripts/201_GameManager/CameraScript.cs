using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCameraExploring;
    public CinemachineVirtualCamera VirtualCameraFighting;
    public CinemachineVirtualCamera[] virtualCamera;

    public PlayerStates playerStates;
    void Start()
    {
        SwitchToCamera(VirtualCameraExploring);
    }

    public void CameraForExploring() // Changing for the Exploring View
    {
        CinemachineVirtualCamera targetCamera = VirtualCameraExploring;
        SwitchToCamera(targetCamera);
    }  
    
    public void CameraForFighting() // Changing for fighting view
    {
        CinemachineVirtualCamera targetCamera = VirtualCameraFighting;
        SwitchToCamera(targetCamera);
    }
    
    public void SwitchToCamera(CinemachineVirtualCamera targetCamera) // Method for switching camera in a list
    {
        foreach (CinemachineVirtualCamera camera in virtualCamera)
        {
            camera.enabled = camera == targetCamera;
        }
    }
}
