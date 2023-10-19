using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Harpoon : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    public Camera mainCamera;

    public RaycastHit hit;

    [SerializeField] private GameObject mainCameraPrefab;

    [SerializeField] private bool isShooted;


    public void Start()
    {
        mainCamera = Camera.main;
        isShooted = false;
    }

    public void Update()

    {
        GetMousePosition();
        Aim();
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast (ray, out var hitInfo, Mathf.Infinity)) 
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }

    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            var direction = position - transform.position;

            transform.forward = direction;
        }
    }
}
