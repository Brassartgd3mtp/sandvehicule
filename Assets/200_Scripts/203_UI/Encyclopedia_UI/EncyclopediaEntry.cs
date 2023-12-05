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
        // V�rifie si le joueur est dans le layer sp�cifi� par le LayerMask
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            encyclopediaManager.AddEntry(associatedEntryID);
            // Ajoute d'autres actions si n�cessaire (comme d�sactiver l'objet pour �viter une double entr�e)
            Destroy(gameObject);
        }
    }

    public void InitializeEntry(GameObject associatedObject)
    {
        encyclopediaManager.entryGameObjectMap.Add(associatedEntryID, associatedObject);
    }
}