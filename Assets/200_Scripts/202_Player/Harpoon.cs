using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TreeEditor;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Harpoon : MonoBehaviour
{
    public RaycastHit hitPerma;
    public RaycastHit hitOnClick;

    [SerializeField] private GameObject harpoonStart;
    [SerializeField] private GameObject player;

    public Camera mainCamera;
    public CinemachineVirtualCamera VirtualCamera;
    [SerializeField] private GameObject mainCameraPrefab;

    public bool isShooted;
    public bool harpoonReadyToBack = false;

    public float harpoonSpeed;

    public bool harpoonIsReady;

    public Vector3 harpoonTarget;
    public LineRenderer LR;

    public Rigidbody rb;

    public GameObject StickyPoint;
    public GameObject itemHooked;
    public GameObject bodyVehicule;
    public GameObject HarpoonParent;

    public PlayerStates playerStates;

    public bool collideSomething;

    new public Collider collider;

    public void Start()
    {
        mainCamera = Camera.main;
        isShooted = false;
        collider = GetComponent<Collider>();

        harpoonIsReady = true;
    }

    public void Update()
    {
        if (isShooted == false) // Si le harpon n'est pas tiré, permet de récupérer le click de la souris sur le screen
        {
            GetMousePosition();
            Aim();
        }  

        if(isShooted && !collideSomething) //Le harpon va vers l'endroit clické
        { 
            HarpoonMoveToSpot();
        }

        if (harpoonReadyToBack) // le harpon a touché sa cible ou a atteint la longeur maximale ou a été rappelé 
        { 
            harpoonBack();
        }

        if(harpoonIsReady) // Check si le harpon est prêt à être tiré
        {
            LR.enabled = false;
            harpoonStart.transform.position = transform.position;
        }
        else
        {
            LR.enabled = true;
            LR.SetPosition(0, harpoonStart.transform.position);
            LR.SetPosition(1, transform.position);
        }

        float cableLength  = Vector3.Distance(harpoonStart.transform.position, transform.position); // taille du cable entre le bout du harpon et la base d'où il est tiré 
        if (cableLength >= 10) // Si la taille maximum du cable est dépassé, force le harpon à être rétracté
        {
            harpoonReadyToBack = true;
            isShooted = false;
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

    public void shootHarpoon()
    {
            harpoonIsReady = false;

            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            var (success, position) = GetMousePosition();

            if (Physics.Raycast(ray, out hitOnClick, Mathf.Infinity))
            {
                isShooted = true;
                harpoonTarget = position;
                harpoonTarget = position;
            } 
    }

    public void HarpoonMoveToSpot() // Le harpon se dirige vers la destination clickée
    {
        if (isShooted)
        {
            collider.enabled = true;
            transform.SetParent(null);
            transform.position = Vector3.Lerp(transform.position, harpoonTarget, harpoonSpeed * Time.deltaTime / Vector3.Distance(transform.position, harpoonTarget));
        }
    }

    public void harpoonBack() // permet de rétracter le harpon vers le véhicule
    {
            collideSomething = false;
            transform.position = Vector3.Lerp(transform.position, harpoonStart.transform.position, harpoonSpeed * Time.deltaTime / Vector3.Distance(transform.position, harpoonStart.transform.position));
            transform.LookAt(harpoonTarget);

            if (harpoonStart.transform.position == transform.position)
            {
                transform.SetParent(HarpoonParent.transform);
                ResetHarpoon();
            }
    }

    public void ResetHarpoon() // Reset le harpon pour un nouveau tir 
    {
        isShooted = false;
        harpoonReadyToBack = false;
        harpoonIsReady = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Harpoon")
        {
            collider.enabled = false;
            Debug.Log("touched");
            isShooted = false;
            harpoonReadyToBack = true;
        }

        if (collision.gameObject.tag == "Item") // Stick un item et enclenche le fait de le ramener vers le véhicule 
        {
            collider.enabled = false;
            Debug.Log("detectobj");
            isShooted = false;
            harpoonReadyToBack = true;
            itemHooked = collision.gameObject;            
            itemHooked.transform.parent = StickyPoint.transform;
        }


    }

    
}
