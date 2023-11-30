using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private int priorityBoostAmount = 10;

    private CinemachineVirtualCamera virtualCamera;

    private InputAction aimAction;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aiming"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        virtualCamera.Priority += priorityBoostAmount;
        animator.SetBool("isAiming", true);
    }

    private void CancelAim()
    {
        virtualCamera.Priority -= priorityBoostAmount;
        animator.SetBool("isAiming", false);
    }
}
