using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public Stats stats;

    void Start()
    {
        stats = GetComponent<Stats>();
    }

    public void TakeDamage(float damageAmount) // système de prise de dommages par l'ennemi
    {
        stats.currentHealth -= damageAmount;

        if (stats.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
