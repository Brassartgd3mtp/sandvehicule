using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiParent : MonoBehaviour
{
    public float curretHealth, maxHealth;
    public int Damage;
    public int Level; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount) // syst�me de prise de dommages de l'ennemi
    {
        curretHealth -= damageAmount;

        if (curretHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
