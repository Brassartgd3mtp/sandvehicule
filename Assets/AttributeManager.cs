using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] static int currentHealth;
    [SerializeField] static int maxHealth;
    [SerializeField] static int Damages;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void TakeDamage(int damageAmount) // système de prise de dégats
    {
        currentHealth -= damageAmount;
    }
}
