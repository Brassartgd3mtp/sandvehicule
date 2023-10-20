using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TreeEditor;
using UnityEngine.Rendering;

public class Harpoon : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    public Camera mainCamera;

    public RaycastHit hitPerma;
    public RaycastHit hitOnClick;

    [SerializeField] GameObject harpoonStart;

    [SerializeField] private GameObject mainCameraPrefab;

    public bool isShooted;
    public bool harpoonReadyToBack = false;

    public float harpoonSpeed;

    public bool harpoonIsReady;

    public Vector3 harpoonTarget;
    public LineRenderer LR;

    public Rigidbody rb;

    

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

        if (harpoonReadyToBack == true)
        { 
            harpoonBack();
        }

        if(harpoonIsReady == true) 
        {
            LR.enabled = false;
            harpoonStart.transform.position = transform.position;
        }
        if (harpoonIsReady == false) 
        {
            LR.enabled = true;
            LR.SetPosition(0, harpoonStart.transform.position);
            LR.SetPosition(1, transform.position);
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

        Debug.Log("ShootHarpon");

        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        var (success, position) = GetMousePosition();

        if (Physics.Raycast(ray, out hitOnClick, Mathf.Infinity))
        {
            isShooted = true;
            harpoonTarget = position;
        }
    }

    public void HarpoonMoveToSpot()
    {
        if(isShooted) 
            //rb.velocity = transform.forward * harpoonSpeed;

            //transform.LookAt(harpoonTarget);

            transform.position = Vector3.Lerp(transform.position, harpoonTarget, harpoonSpeed * Time.deltaTime / Vector3.Distance(transform.position, harpoonTarget));


    }

    public void harpoonBack()
    {
        Debug.Log("HarpoonBack");
        {

            transform.position = Vector3.Lerp(transform.position, harpoonStart.transform.position, harpoonSpeed * Time.deltaTime / Vector3.Distance(transform.position, harpoonStart.transform.position));
            transform.LookAt(harpoonTarget);

            if (harpoonStart.transform.position == transform.position)
            {
                ResetHarpoon();
            }
        }
    }

    public void ResetHarpoon()
    {
        isShooted = false;
        harpoonReadyToBack = false;
        harpoonIsReady = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
           
            Debug.Log("touched");
            isShooted = false;
            harpoonReadyToBack = true;
        }
    }
}
