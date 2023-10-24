using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlots assignedInventorySlot;

    private Button button;

    public InventorySlots AssignedInventorySlot => assignedInventorySlot;
    public InventoryDisplay parentDisplay { get; private set;}

    private void Awake()
    {
        ClearSlot();
        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        parentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }
    
    public void Init(InventorySlots slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlots slot)
    {


        if(slot.ItemSO != null) 
        {
            itemSprite.sprite = slot.ItemSO.Icon;
            itemSprite.color = Color.white;

            if (slot.StackSize > 1) itemCount.text = slot.StackSize.ToString();
            else itemCount.text = "";
        }
        else
        {
            ClearSlot();
        }
    }

    public void UpdateUISlot()
    {
        if(assignedInventorySlot != null) UpdateUISlot(assignedInventorySlot);
    }
    public void ClearSlot()
    {
        assignedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    public void OnUISlotClick()
    {
        parentDisplay?.SlotClicked(this);
    }
}
