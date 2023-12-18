using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class ThirdPerson : MonoBehaviour
{
    public static ThirdPerson Instance;

    [SerializeField] private harpoonBrain harpoon;
    [SerializeField] private ItemPickUp itemPickUp;
    [SerializeField] private Animator animator;
    private CharacterController controller;   
    private PlayerInput playerInput;

    [SerializeField] private GameObject UI_Ramasser;
    [SerializeField] private GameObject UI_Parler;

    public Vector3 move;

    public bool isAiming;
    public bool isRunning;

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
    private InputAction interact;
    private InputAction showEncyclopedia;
    private InputAction run;

    [SerializeField] private GameObject targetObjectEncyclopedia;

    private bool canSpeakToWyatt = false;
    [SerializeField] DialogueWyatt dialogueWyatt;
    [SerializeField] DialogueCheyenne dialogueCheyenne;

    private Vector3 prevPos;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        rb = GetComponent<Rigidbody>();

        controller = gameObject.GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;

        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        harpoonBack = playerInput.actions["ForceHarpoonBack"];
        interact = playerInput.actions["Interact"];
        showEncyclopedia = playerInput.actions["ShowEncyclopedia"];
        run = playerInput.actions["Run"];

    }
    public void Start()
    {
        StartCoroutine(CalculateSpeed());
    }

    private void OnEnable()
    {
        shootAction.performed += ShootHarpoon;
        harpoonBack.performed +=ForceHarpoonBack;
        interact.performed += _ => Intercact();
        showEncyclopedia.performed += _ => ShowEncyclopedia();
        run.performed += _ => StartRun();
        run.canceled += _ => CancelRun();
    }

    private void OnDisable()
    {
        shootAction.performed -= ShootHarpoon;
        harpoonBack.performed -= ForceHarpoonBack;
        interact.performed -= _ => Intercact();
        showEncyclopedia.performed -= _ => ShowEncyclopedia();
        run.performed -= _ => StartRun();
        run.canceled -= _ => CancelRun();
    }

    private void ShootHarpoon(InputAction.CallbackContext _context)
    {
        harpoon.ShootHarpoon();
    }

    private void ForceHarpoonBack(InputAction.CallbackContext _context)
    {
        harpoon.isShooted = false;
        harpoon.isMovingBack = true;
    }

    void Update()
    {
        if (actualSpeed > 0 ) 
        {
            animator.SetBool("isMoving", true);
        } 
        if (actualSpeed <= 0)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isMovingBack", false);
            animator.SetBool("isMovingFront", false);
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (isRunning)
        {
            animator.SetBool("isRunning", true);
            playerSpeed = 8f;
        }
        else if (!isRunning)
        {
            animator.SetBool("isRunning", false);
            playerSpeed = 4f;
        }

        if (isAiming)
        {
            isRunning = false;
            playerSpeed = 1f;
        }

        if (move.z > 0 && isAiming)
        {
            animator.SetBool("isMovingFront", true);
            animator.SetBool("isMovingBack", false);
        }
        if (move.z < 0 && isAiming)
        {
            animator.SetBool("isMovingBack", true);
            animator.SetBool("isMovingFront", false);
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            animator.SetBool("isJumping", true);
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

    public void StartRun()
    {
        isRunning = true;
    }

    public void CancelRun()
    {
        isRunning = false;
    }

    public void Intercact()
    {
        if (itemPickUp != null)
        {
            itemPickUp.PickUp();
            UI_Ramasser.SetActive(false);
        }

        if (dialogueWyatt.canSpeak)
        {
            dialogueWyatt.StartDialogue2Wyatt();
        }

        if(dialogueCheyenne.canSpeak) 
        {
            Debug.Log("La");
            dialogueCheyenne.StartDialogue2Cheyenne();
        }
    }

    public void ShowEncyclopedia()
    {
        if (targetObjectEncyclopedia != null)
        {
            targetObjectEncyclopedia.SetActive(!targetObjectEncyclopedia.activeSelf);

            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            } else Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Item"))
        {
            itemPickUp = other.gameObject.GetComponent<ItemPickUp>();
            UI_Ramasser.SetActive(true);
        }

        if (other.gameObject.TryGetComponent(out DialogueWyatt dialogueWyatt))
        {
            if (dialogueWyatt.canSpeak)
            {
                dialogueWyatt.StartDialogue2Wyatt();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Item"))
        {
            itemPickUp = null;
            UI_Ramasser.SetActive(false);

        }
    }

    public void PlayFootstepsSand()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        int[] soundsIdsSand = { 12, 13, 14, 15 };
        int randomIndexSand = Random.Range(0, soundsIdsSand.Length);
        int randomSoundIdSand = soundsIdsSand[randomIndexSand];
        AudioManager.Instance.PlaySound(randomSoundIdSand, audioSource);
    }
}
