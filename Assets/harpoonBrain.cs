using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class harpoonBrain : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] new Collider collider;
    [SerializeField] public LayerMask layerMask;

    public bool isShooted;
    public bool isMovingOn, isMovingBack;

    [SerializeField] Vector3 targetObject;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject harpoonTargetEmpty;
    [SerializeField] private GameObject harpoonStart;
    [SerializeField] private GameObject itemHooked;

    [SerializeField] LineRenderer LR;

    [SerializeField] float harpoonSpeed;

    public void Awake()
    {
        collider = GetComponent<Collider>();
    }

    public void Update()
    {
        if (isShooted && isMovingOn)
        {
            isMovingToSpot();
        }

        if (isShooted && isMovingBack)
        {
            isMovingToPlayer();
        }

        if (isShooted)
        {
            LR.SetPosition(0, harpoonStart.transform.position);
            LR.SetPosition(1, transform.position);

            float cableLength = Vector3.Distance(harpoonStart.transform.position, transform.position); // taille du cable entre le bout du harpon et la base d'où il est tiré 
            if (cableLength >= 10) // Si la taille maximum du cable est dépassé, force le harpon à être rétracté
            {
                isMovingOn = false;
                isMovingBack = true;
            }
        }

    }

    public void ShootHarpoon()
    {
        if (!isShooted) 
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 10))
            {
                targetObject = hit.point;
                //if (hit.collider.gameObject == gameObject.CompareTag("Item"))
                //{
                //    Debug.Log("Item");
                //    targetObject = collider.gameObject;
                //}
                //if (hit.collider.gameObject == gameObject.CompareTag("Ground"))
                //{
                //    Debug.Log("Ground");
                //    targetObject = collider.gameObject;
                //}
                //
                //if (hit.collider.gameObject == null)
                //{
                //    Debug.Log("Empty");
                //    targetObject = harpoonTargetEmpty;
                //}
            }
            else targetObject = harpoonTargetEmpty.transform.position;
            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 10, Color.red, 2);
            isShooted = true;
            LR.enabled = true;
            isMovingOn = true;
            transform.SetParent(null);
            collider.enabled = true;
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == true)
        {
            isMovingOn = false;
            isMovingBack = true;
            collider.enabled = false;
        }

        if (collision.gameObject == gameObject.CompareTag("Item"))
        {
            itemHooked = collision.gameObject;
            itemHooked.transform.parent = this.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == harpoonTargetEmpty)
        {
            isMovingOn = false;
            isMovingBack = true;
            collider.enabled = false;
        }
    }
    public void isMovingToSpot()
    {
        transform.position = Vector3.Lerp(transform.position, targetObject, harpoonSpeed * Time.deltaTime / Vector3.Distance(transform.position, targetObject));

    }

    public void isMovingToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, harpoonStart.transform.position, harpoonSpeed * Time.deltaTime / Vector3.Distance(transform.position, harpoonStart.transform.position));

        if (harpoonStart.transform.position == transform.position)
        {
            transform.SetParent(Player.transform);
            ResetHarpoon();
        }
    }

    public void ResetHarpoon()
    {
        LR.enabled = false;
        isShooted = false;
        isMovingBack = false;
    }
}
