using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaInputTest : MonoBehaviour
{
    public GameObject targetObject;
    public KeyCode activationKey = KeyCode.E;

    void Update()
    {
        // Vérifie si la touche d'activation est enfoncée
        if (Input.GetKeyDown(activationKey))
        {
            // Active ou désactive le GameObject cible en fonction de son état actuel
            if (targetObject != null)
            {
                targetObject.SetActive(!targetObject.activeSelf);
            }
        }
    }
}
