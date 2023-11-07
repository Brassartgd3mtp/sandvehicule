using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TreeEditor;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;

public class Harpoon : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    public Camera mainCamera;

    public RaycastHit hitPerma;
    public RaycastHit hitOnClick;

    [SerializeField] UnityEngine.GameObject harpoonStart;

    [SerializeField] private UnityEngine.GameObject mainCameraPrefab;

    public bool isShooted;
    public bool harpoonReadyToBack = false;

    public float harpoonSpeed;

    public bool harpoonIsReady;

    public Vector3 harpoonTarget;
    public LineRenderer LR;

    public Rigidbody rb;

    public GameObject StickyPoint;
    public GameObject itemHooked;

    public GameObject HarpoonParent;

    public PlayerStates playerStates;

    public float rotationRadius;
    public float angularSpeed;
    public float posX, posZ, angle = 0f;

    public GameObject ObjectSticked;
    public GameObject player;

    public bool isOrbited;

    public void Start()
    {
        mainCamera = Camera.main;
        isShooted = false;

        harpoonIsReady = true;
    }

    public void Update()
    {
        if (isShooted == false)
        {
            GetMousePosition();
            Aim();
        }  

        if(isShooted) 
        { 
            HarpoonMoveToSpot();
        }

        if (harpoonReadyToBack)
        { 
            harpoonBack();
        }

        if(harpoonIsReady) 
        {
            LR.enabled = false;
            harpoonStart.transform.position = transform.position;
        }
        if (!harpoonIsReady ) 
        {
            LR.enabled = true;
            LR.SetPosition(0, harpoonStart.transform.position);
            LR.SetPosition(1, transform.position);
        }

        if (isOrbited) // Lorsque l'on a harponné un objet qui peut nous faire tourner 
        {
            posX = transform.position.x + Mathf.Cos(angle) * rotationRadius;
            posZ = transform.position.z + Mathf.Sin(angle) * rotationRadius;
            player.transform.position = new Vector3(posX, 0, posZ);
            angle = angle + Time.deltaTime * angularSpeed;

            if (angle >= Mathf.PI) angle = -Mathf.PI;
        }
    }

    private (bool success, Vector3 position) GetMousePosition() // recupère la position de la souris dans l'espace
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

    public LayerMask layerMask;
    public void shootHarpoon()
    {
        if (playerStates.states == PlayerStates.States.Exploring)
        {
            harpoonIsReady = false;

            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            var (success, position) = GetMousePosition();

            if (Physics.Raycast(ray, out hitOnClick, Mathf.Infinity, layerMask))
            {
                isShooted = true;
                harpoonTarget = position;
            } 
        }

    }

    public void HarpoonMoveToSpot()
    {
        if (isShooted)
        {
            transform.SetParent(null);
            transform.position = Vector3.MoveTowards(transform.position, harpoonTarget, harpoonSpeed * Time.deltaTime / Vector3.Distance(transform.position, harpoonTarget));
        }
    }

    public void harpoonBack() // permet de rétracter le harpon vers le véhicule
    {
            transform.position = Vector3.Lerp(transform.position, harpoonStart.transform.position, harpoonSpeed * Time.deltaTime / Vector3.Distance(transform.position, harpoonStart.transform.position));
            transform.LookAt(harpoonTarget);

            if (harpoonStart.transform.position == transform.position)
            {
                transform.SetParent(HarpoonParent.transform);
                ResetHarpoon();
            }
    }

    public void ResetHarpoon()
    {
        isShooted = false;
        harpoonReadyToBack = false;
        harpoonIsReady = true;
    }// Reset le harpon pour un nouveau tir 

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Harpoon")
        {
           
            Debug.Log("touched");
            isShooted = false;
            harpoonReadyToBack = true;
        }

        if (collision.gameObject.tag == "Item") 
        {
            Debug.Log("detectobj");
            isShooted = false;
            harpoonReadyToBack = true;
            itemHooked = collision.gameObject;            
            itemHooked.transform.parent = StickyPoint.transform;
        }

        // Collision avec les objets autour desquels on peut tourner
        if (collision.gameObject.tag == "Orbital")
        {
            ObjectSticked = collision.gameObject;
            rotationRadius = Vector3.Distance(player.transform.position, transform.position);
            isOrbited = true;
            Vector3 currentPosition = player.transform.position - transform.position;
            angle = Mathf.Atan2(currentPosition.z, currentPosition.x);
        }
    }
}
