using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;

    public int damage;

    public float attackSpeed;

    public int InventorySlots;

    public float maxSpeed;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }
}
