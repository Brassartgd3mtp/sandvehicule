using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class TornadoFXPlay : MonoBehaviour
{
    public VisualEffect monEffetVisuel; // Assure-toi de faire référence à ton VisualEffect Asset dans l'Inspector.

    void Start()
    {
        // Tu peux également accéder à l'effet visuel via le code, par exemple :
        // monEffetVisuel = GetComponent<VisualEffect>();

        // Vérifie si l'effet visuel existe avant de le jouer
        if (monEffetVisuel != null)
        {
            monEffetVisuel.Play();
        }
        else
        {
            Debug.LogError("L'effet visuel n'est pas référencé dans le script.");
        }
    }
}
