using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaInputTest : MonoBehaviour
{
    public GameObject targetObject;
    public KeyCode activationKey = KeyCode.E;

    void Update()
    {
        // V�rifie si la touche d'activation est enfonc�e
        if (Input.GetKeyDown(activationKey))
        {
            // Active ou d�sactive le GameObject cible en fonction de son �tat actuel
            if (targetObject != null)
            {
                targetObject.SetActive(!targetObject.activeSelf);
            }
        }
    }
}
