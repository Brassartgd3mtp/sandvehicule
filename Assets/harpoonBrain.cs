using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harpoonBrain : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    [SerializeField] public LayerMask layerMask;

    public bool isShooted;
    public bool isMovingOn, isMovingBack;

    [SerializeField] Transform targetTransform;
    [SerializeField] GameObject harpoonTargetEmpty;
    public void Update()
    {

        Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 10, Color.red);
    }

    public void isMovingToSpot()
    {

    }

    public void ShootHarpoon()
    {
        isShooted = true;
        isMovingOn = true;

        RaycastHit hit;
        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, Mathf.Infinity)) 
        {
            if (hit.collider.gameObject == gameObject.CompareTag("Item"))
            {
                targetTransform = hit.collider.gameObject.transform;
            }
            if (hit.collider.gameObject == gameObject.CompareTag("Ground"))
            {
                targetTransform = hit.transform;
            }

            if (hit.collider.gameObject == null)
            {
                targetTransform = harpoonTargetEmpty.transform;
            }
        }
    }
}
