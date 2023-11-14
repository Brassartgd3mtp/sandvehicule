using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class TornadoFXPlay : MonoBehaviour
{
    public VisualEffect monEffetVisuel; // Assure-toi de faire référence à ton VisualEffect Asset dans l'Inspector.
    public float noisePowerRing = 0f;
    public float noisePowerCore = 0f;

    public float noisePowerRingDuration = 5f;  // Durée pour passer de 0 à 1 pour noisePowerRing
    public float noisePowerCoreDuration = 10f; // Durée pour passer de 0 à 1 pour noisePowerCore


    void Start()
    {
        // Tu peux également accéder à l'effet visuel via le code, par exemple :
        // monEffetVisuel = GetComponent<VisualEffect>();

        // Vérifie si l'effet visuel existe avant de le jouer
        if (monEffetVisuel != null)
        {
            // Démarre la coroutine pour augmenter progressivement le bruit
            monEffetVisuel.Play();
            StartCoroutine(AnimateNoiseValues());
            StartCoroutine(AnimateNoiseCore());
            //Invoke("StarAnimateNoiseCore", noisePowerRingDuration - 1);
        }
        else
        {
            Debug.LogError("L'effet visuel n'est pas référencé dans le script.");
        }
    }



    void StarAnimateNoiseCore()
    {
        StartCoroutine(AnimateNoiseCore());
    }

    IEnumerator AnimateNoiseValues()
    {
        float elapsedTime = 0f;

        // Progression du bruit pour noisePowerRing
        while (elapsedTime < noisePowerRingDuration)
        {
            float t = elapsedTime / noisePowerRingDuration;
            monEffetVisuel.SetFloat("NoisePowerRing", Mathf.Lerp(0f, 1f, t));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator AnimateNoiseCore()
    {
        float elapsedTime = 0f;
        // Progression du bruit pour noisePowerCore
        elapsedTime = 0f;
        while (elapsedTime < noisePowerCoreDuration)
        {
            float t = elapsedTime / noisePowerCoreDuration;
            monEffetVisuel.SetFloat("NoisePowerCore", Mathf.Lerp(0f, 1f, t));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
