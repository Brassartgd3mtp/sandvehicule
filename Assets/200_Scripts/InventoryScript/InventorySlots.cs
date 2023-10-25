using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventorySlots
{
    [SerializeField] private ItemSO itemSO; // reference aux data de l'item
    [SerializeField] private int stackSize; // Actuel nombre d'item sur le stack

    public ItemSO ItemSO => itemSO;
    public int StackSize => stackSize;  

    public InventorySlots(ItemSO source, int amount) // Constructor pour faire un slot occupé
    {
        itemSO = source;
        stackSize = amount;
    }

    public InventorySlots() // Constructor pour faire un slot vide
    {
        ClearSlot();
    }

    public void ClearSlot() // Pour vider un slot 
    {
        itemSO = null;
        stackSize = -1;
    }

    public void AssignItem(InventorySlots invSlot) // Assigne un item à un slot 
    {
        if (itemSO == invSlot.itemSO) AddToStack(invSlot.stackSize); // Demande si le slot contient le même item, si oui l'ajoute au slot 
        else // Overwrite slot with the inventory slot what we re passing in 
        {
            itemSO = invSlot.itemSO;
            stackSize = 0;
            AddToStack(invSlot.stackSize);
        }
    }
    public void UpdateInventorySlots(ItemSO data, int amount) // Updates l'état du slot 
    {
        itemSO = data;
        stackSize = amount;
    }

    public bool EnoughRoomLeftInStack(int amountToAdd, out int amountRemaining) // Est ce qu'il y a assez de place pour stack la somme que l'on essaie d'ajouter 
    {
        amountRemaining = itemSO.MaxStackSize - stackSize;
        return EnoughRoomLeftInStack(amountToAdd);
    }

    public bool EnoughRoomLeftInStack(int amountToAdd)   
    {
        if( itemSO == null || itemSO != null && stackSize + amountToAdd <= itemSO.MaxStackSize) return true;
        else return false;
    }

    public void AddToStack(int amount) 
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount) 
    {
        stackSize -= amount;
    }

    public bool SplitStack(out InventorySlots splitStack) 
    {
        if (stackSize <= 1) // est ce qu'il y en a assez pour split? si non return false et rien ne se passe
        {
            splitStack = null;
            return false;
        }

        int halfStack = Mathf.RoundToInt(stackSize / 2); // Donne la moitié du stack
        RemoveFromStack(halfStack);

        splitStack = new InventorySlots(itemSO, halfStack); // créé un copie de ce slot avec la moitié du la taille du stack

        return true;

    }
}
