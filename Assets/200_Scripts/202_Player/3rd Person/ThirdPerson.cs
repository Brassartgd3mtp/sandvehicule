using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private harpoonBrain harpoon;
    [SerializeField] private Animator animator;
    private CharacterController controller;   
    private PlayerInput playerInput;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public Rigidbody rb;

    private Transform cameraTransform;


    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float actualSpeed;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;
    private InputAction harpoonBack;

    private Vector3 prevPos;

    public void Start()
    {
        StartCoroutine(CalculateSpeed());
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        controller = gameObject.GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;

        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        harpoonBack = playerInput.actions["ForceHarpoonBack"];
    }

    private void OnEnable()
    {
        shootAction.performed += _ => ShootHarpoon();
        harpoonBack.performed += _ => ForceHarpoonBack();
    }

    private void OnDisable()
    {
        shootAction.performed -= _ => ShootHarpoon();
        harpoonBack.performed -= _ => ForceHarpoonBack();
    }

    private void ShootHarpoon()
    {
        harpoon.ShootHarpoon();
    }

    private void ForceHarpoonBack()
    {
        harpoon.isShooted = false;
        harpoon.isMovingBack = true;
    }

    void Update()
    {
        if (actualSpeed > 0 ) 
        {
            animator.SetBool("isMoving", true);
        } if (actualSpeed <= 0)
        {
            animator.SetBool("isMoving", false);
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;

        controller.Move(move * Time.deltaTime * playerSpeed);


        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //Rotate towards camera direction
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    IEnumerator CalculateSpeed()
    {
        bool isPlaying = true;

        while (isPlaying) 
        {
            prevPos = transform.position;

            yield return new WaitForFixedUpdate();

            actualSpeed = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.deltaTime);
        }
    }
}
