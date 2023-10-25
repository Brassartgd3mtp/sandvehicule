using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class PlayerInventoryHolder : InventoryHolder
{
    [SerializeField] protected int secondaryInventorySize;
    [SerializeField] protected InventorySystem secondaryInventorySystem;

    public InventorySystem SecondaryInventorySystem => secondaryInventorySystem;

    public static UnityAction<InventorySystem> OnPlayerBackPackDisplayRequest;

    protected override void Awake()
    {
        base.Awake();

        secondaryInventorySystem = new InventorySystem(secondaryInventorySize);
    }

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame) OnPlayerBackPackDisplayRequest?.Invoke(secondaryInventorySystem);
    }

    public bool AddToInventory(ItemSO data, int amount)
    {
        if (primaryInventorySystem.AddToInventory(data, amount))
        {
            return true;
        }
        else if (secondaryInventorySystem.AddToInventory(data,amount)) 
        {
            return true;
        }
        return false;
    }
}
