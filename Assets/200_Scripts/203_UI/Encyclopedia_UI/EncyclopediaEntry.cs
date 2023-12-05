using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaEntry : MonoBehaviour
{
    public int associatedEntryID;
    public EncyclopediaManager encyclopediaManager;
    public LayerMask playerLayer;

    private void Start()
    {
        encyclopediaManager = EncyclopediaManager.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur est dans le layer spécifié par le LayerMask
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            encyclopediaManager.AddEntry(associatedEntryID);
            // Ajoute d'autres actions si nécessaire (comme désactiver l'objet pour éviter une double entrée)
            Destroy(gameObject);
        }
    }

    public void InitializeEntry(GameObject associatedObject)
    {
        encyclopediaManager.entryGameObjectMap.Add(associatedEntryID, associatedObject);
    }
}