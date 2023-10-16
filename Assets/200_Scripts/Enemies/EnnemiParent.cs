using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiParent : MonoBehaviour
{
    public float curretHealth, maxHealth;
    public float Damage;
    public int Level;
    public float attackSpeed;
    public bool atRangeOfPlayer;

    public GameObject gameManager;
    public WaveSystem waveSystem;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        waveSystem = gameManager.GetComponent<WaveSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount) // système de prise de dommages de l'ennemi
    {
        curretHealth -= damageAmount;

        if (curretHealth <= 0)
        {
            waveSystem.enemyCount--;
            Destroy(gameObject);
        }
    }


}
