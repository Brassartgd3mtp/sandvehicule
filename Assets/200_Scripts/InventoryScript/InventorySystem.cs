using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;


[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlots> inventorySlots;

    public List<InventorySlots> InventorySlots => inventorySlots;
    public int InventorySize => inventorySlots.Count;

    public UnityAction<InventorySlots> OnInventorySlotChanged;

    public InventorySystem(int size) // Constructor qui set la somme de slot
    {
        inventorySlots = new List<InventorySlots>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlots());
        }
    }

    public bool AddToInventory(ItemSO itemToAdd, int amountToAdd)  
    {
        if (ContainsItem(itemToAdd, out List<InventorySlots> invSlots)) //Check whether item exists in inventory
        {
            foreach (var slot in invSlots)
            {
                if (slot.EnoughRoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }

        }
        if (HasFreeSlot(out InventorySlots freeSlots)) // Gets the first available slot
        {
            if (freeSlots.EnoughRoomLeftInStack(amountToAdd))
            {
                freeSlots.UpdateInventorySlots(itemToAdd, amountToAdd);
                OnInventorySlotChanged?.Invoke(freeSlots);
                return true;
            }             
        }
        return false;
    }

    public bool ContainsItem(ItemSO itemToAdd, out List<InventorySlots> invSlots) // L'un de nos emplacements contient-il l'élément à ajouter ?
    {
        invSlots = InventorySlots.Where(i => i.ItemSO == itemToAdd).ToList(); // Si oui, récupère la list
        return invSlots == null ? false : true; // Si oui return True, si non return False
    }

    public bool HasFreeSlot(out InventorySlots freeSlots) 
    {
        freeSlots = InventorySlots.FirstOrDefault(i => i.ItemSO == null); //Donne le premier slot vide 
        return freeSlots
            == null ? false : true;
    }
}
