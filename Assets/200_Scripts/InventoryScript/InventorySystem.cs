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

    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlots>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlots());
        }
    }

    public bool AddToInventory(ItemSO itemToAdd, int amountToAdd)  //Check whether item exists in inventory
    {
        if (ContainsItem(itemToAdd, out List<InventorySlots> invSlots))
        {
            foreach (var slot in invSlots)
            {
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }

        }
        if (HasFreeSlot(out InventorySlots freeSlots)) // Gets the first available slot
        {
            freeSlots.UpdateInventorySlots(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlots);
            return true;
        }
        return false;
    }

    public bool ContainsItem(ItemSO itemToAdd, out List<InventorySlots> invSlots)
    {
        invSlots = InventorySlots.Where(i => i.ItemSO == itemToAdd).ToList();
        Debug.Log(invSlots.Count);
        return invSlots == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlots freeSlots) 
    {
        freeSlots = InventorySlots.FirstOrDefault(i => i.ItemSO == null); 
        return freeSlots
            == null ? false : true;
    }
}
