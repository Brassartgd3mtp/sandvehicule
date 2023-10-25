using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUICOntroller : MonoBehaviour
{
    public DynamicInventoryDisplay chestPanel;
    public DynamicInventoryDisplay playerBackPackPanel;


    public void Awake()
    {
        chestPanel.gameObject.SetActive(false);
        playerBackPackPanel.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequest += DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackPackDisplayRequest += DisplayPlayerBackpack;
    }

    private void OnDisable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequest += DisplayInventory;
    }

    public void Update()
    {
        if(chestPanel.gameObject.activeInHierarchy && Keyboard.current.escapeKey.wasPressedThisFrame) 
           chestPanel.gameObject.SetActive(false);

        if (playerBackPackPanel.gameObject.activeInHierarchy && Keyboard.current.escapeKey.wasPressedThisFrame)
            playerBackPackPanel.gameObject.SetActive(false);
    }

    void DisplayInventory(InventorySystem invToDisplay)
    {
        chestPanel.gameObject.SetActive(true);
        chestPanel.RefreshDynamicInventory(invToDisplay);
    }

    void DisplayPlayerBackpack(InventorySystem invToDisplay)
    {
        playerBackPackPanel.gameObject.SetActive(true);
        playerBackPackPanel.RefreshDynamicInventory(invToDisplay);
    }
}
