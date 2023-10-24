using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlots> slotDictionary;
    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlots> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {

    }

    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void UpdateSlot(InventorySlots updateSlot)
    {
        foreach (var slot in slotDictionary) // Slot value - the "under the hood" Inventory slot
        {
            if (slot.Value == updateSlot)
            {
                slot.Key.UpdateUISlot(updateSlot); // Slot key - the UI representation of the value
            }
        }
    }

    public void  SlotClicked(InventorySlot_UI clickedUISlot)
    {
        bool isShiftPressed = Keyboard.current.leftShiftKey.isPressed;

        if (clickedUISlot.AssignedInventorySlot.ItemSO != null && mouseInventoryItem.AssignedInventorySlot.ItemSO == null)
        {
            if (isShiftPressed && clickedUISlot.AssignedInventorySlot.SplitStack(out InventorySlots halfStackSlot)) // split stack
            {
                mouseInventoryItem.UpdateMouseSlot(halfStackSlot);
                clickedUISlot.UpdateUISlot();
                return;
            }
            else
            {
                mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
                clickedUISlot.ClearSlot();
                return;
            }


        }

        if (clickedUISlot.AssignedInventorySlot.ItemSO == null && mouseInventoryItem.AssignedInventorySlot.ItemSO != null)
        {
            clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
        }

        // Both slots have an item
        if (clickedUISlot.AssignedInventorySlot.ItemSO != null && mouseInventoryItem.AssignedInventorySlot.ItemSO != null)
        {
            bool isSameItem = clickedUISlot.AssignedInventorySlot.ItemSO == mouseInventoryItem.AssignedInventorySlot.ItemSO;

                if (isSameItem && clickedUISlot.AssignedInventorySlot.RoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize))
            {
                clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
                clickedUISlot.UpdateUISlot();

                mouseInventoryItem.ClearSlot();
            }
                else if (isSameItem && !clickedUISlot.AssignedInventorySlot.RoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize, out int leftInTheStack)) 
            {
                if (leftInTheStack < 1) SwapSlots(clickedUISlot); //Stack is full so swap the items
                else // slot is not at max, so take what's need from the mouse inventory
                {
                    int remainingOnMouse = mouseInventoryItem.AssignedInventorySlot.StackSize - leftInTheStack;
                    clickedUISlot.AssignedInventorySlot.AddToStack(leftInTheStack);
                    clickedUISlot.UpdateUISlot();

                    var newItem = new InventorySlots(mouseInventoryItem.AssignedInventorySlot.ItemSO, remainingOnMouse);
                    mouseInventoryItem.ClearSlot();
                    mouseInventoryItem.UpdateMouseSlot(newItem);
                    return;
                }
            }
                else if (!isSameItem) 
            {
                SwapSlots(clickedUISlot);
            }
        }
;
    }

    private void SwapSlots(InventorySlot_UI clickedUISlot)
    {
        var clonedSlot = new InventorySlots(mouseInventoryItem.AssignedInventorySlot.ItemSO, mouseInventoryItem.AssignedInventorySlot.StackSize);
        mouseInventoryItem.ClearSlot();

        mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);

        clickedUISlot.ClearSlot();
        clickedUISlot.AssignedInventorySlot.AssignItem(clonedSlot);
        clickedUISlot.UpdateUISlot();
    }

}
