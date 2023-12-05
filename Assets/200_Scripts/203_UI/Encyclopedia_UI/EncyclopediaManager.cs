using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntryGameObjectPair
{
    public int entryID;
    public GameObject associatedObject;
}

public class EncyclopediaManager : MonoBehaviour
{
    public static EncyclopediaManager Instance;

    public List<ItemSO> allEntries = new List<ItemSO>();
    public List<EntryGameObjectPair> entryGameObjectPairs = new List<EntryGameObjectPair>();

    public Dictionary<int, GameObject> entryGameObjectMap = new Dictionary<int, GameObject>();

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        // Remplis le dictionnaire lors du démarrage
        foreach (var pair in entryGameObjectPairs)
        {
            entryGameObjectMap[pair.entryID] = pair.associatedObject;
        }
    }

    public void AddEntry(int entryID)
    {
        ItemSO newEntry = GetEntryByID(entryID);

        //if (newEntry != null)
        //{
            // Active le GameObject associé à cette entrée
            if (entryGameObjectMap.ContainsKey(entryID))
            {
                entryGameObjectMap[entryID].SetActive(true);
            }
        //}
    }

    private ItemSO GetEntryByID(int entryID)
    {
        return allEntries.Find(entry => entry.ID == entryID);
    }
}
