using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera WyattCamera;
    public void Start()
    {
        WyattCamera.Priority = 15;
    }

}
