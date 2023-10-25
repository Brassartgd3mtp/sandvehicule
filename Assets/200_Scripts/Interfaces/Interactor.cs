
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Transform interactionPoint;
    public LayerMask interactionLayer;
    public float interactionPointRadius;
    public bool isInteracting {  get; private set; }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(interactionPoint.position, interactionPointRadius, interactionLayer);

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            for (int i = 0; i < colliders.Length; i++) 
            {
                var interactible = colliders[i].GetComponent<IInteractable>();

                if (interactible != null) StartInteraction(interactible);
            }
        }
    }

    void StartInteraction(IInteractable interactible)
    {
        interactible.Interact(this, out bool interctSuccessful);
        isInteracting = true;
    }

    void EndInteraction()
    {
        isInteracting = false;
    }
}
