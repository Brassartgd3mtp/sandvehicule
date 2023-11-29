using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaManager : MonoBehaviour
{
    public List<ItemSO> allEntries = new List<ItemSO>();

    public void AddEntry(int entryID)
    {
        ItemSO newEntry = GetEntryByID(entryID);

        if (newEntry != null)
        {
            // Ajoute le code pour afficher les informations dans l'interface du bestiaire
            Debug.Log("Nouvelle entrée dans le bestiaire : " + newEntry.Name);
        }
    }

    private ItemSO GetEntryByID(int entryID)
    {
        return allEntries.Find(entry => entry.ID == entryID);
    }
}
