using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class TornadoFXPlay : MonoBehaviour
{
    public VisualEffect monEffetVisuel; // Assure-toi de faire r�f�rence � ton VisualEffect Asset dans l'Inspector.

    void Start()
    {
        // Tu peux �galement acc�der � l'effet visuel via le code, par exemple :
        // monEffetVisuel = GetComponent<VisualEffect>();

        // V�rifie si l'effet visuel existe avant de le jouer
        if (monEffetVisuel != null)
        {
            monEffetVisuel.Play();
        }
        else
        {
            Debug.LogError("L'effet visuel n'est pas r�f�renc� dans le script.");
        }
    }
}
