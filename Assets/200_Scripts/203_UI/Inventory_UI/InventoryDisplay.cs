using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlots> slotDictionary; //associez les emplacements de l'interface utilisateur aux emplacements du système
    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlots> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {

    }

    public abstract void AssignSlot(InventorySystem invToDisplay); // Implémenté dans la classe enfant 

    protected virtual void UpdateSlot(InventorySlots updateSlot)
    {
        foreach (var slot in slotDictionary) 
        {
            if (slot.Value == updateSlot)// Slot value - the "under the hood" Inventory slot
            {
                slot.Key.UpdateUISlot(updateSlot); // Slot key - the UI representation of the value
            }
        }
    }

    public void  SlotClicked(InventorySlot_UI clickedUISlot)
    {
        bool isShiftPressed = Keyboard.current.leftShiftKey.isPressed;
        // Est ce que le slot clické possède un item? est ce que la souris a un item ?
        
        if (clickedUISlot.AssignedInventorySlot.ItemSO != null && mouseInventoryItem.AssignedInventorySlot.ItemSO == null)
        {
            // Si le joueur appuie sur Shift? Split le stack
            if (isShiftPressed && clickedUISlot.AssignedInventorySlot.SplitStack(out InventorySlots halfStackSlot)) // split stack
            {
                mouseInventoryItem.UpdateMouseSlot(halfStackSlot);
                clickedUISlot.UpdateUISlot();
                return;
            }
            else // Récupère l'item sur le slot clické 
            {
                mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
                clickedUISlot.ClearSlot();
                return;
            }
        }

        // Le slot clické n'a pas d'item - le souris a un item, place la l'item de la souris sur le slot vide 
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

                // Est ce que les deux item sont identiques ? si oui, on les combine 
                if (isSameItem && clickedUISlot.AssignedInventorySlot.EnoughRoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize))
            {
                clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
                clickedUISlot.UpdateUISlot();

                mouseInventoryItem.ClearSlot();
            }
                
                else if (isSameItem && !clickedUISlot.AssignedInventorySlot.EnoughRoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize, out int leftInTheStack)) 
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
