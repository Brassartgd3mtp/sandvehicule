using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventorySlots
{
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private int stackSize;

    public ItemSO ItemSO => itemSO;
    public int StackSize => stackSize;  

    public InventorySlots(ItemSO source, int amount)
    {
        itemSO = source;
        stackSize = amount;
    }

    public InventorySlots() 
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemSO = null;
        stackSize = -1;
    }

    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining)
    {
        amountRemaining = itemSO.MaxStackSize - stackSize;
        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd) 
    {
        if(stackSize + amountToAdd <= itemSO.MaxStackSize) return true;
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
}
