using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiParent : MonoBehaviour
{
    public EnemyControl enemyControl;

    public GameObject gameManager;
    public WaveSystem waveSystem;

    public Rigidbody rb;

    void Awake()
    {
        enemyControl = GetComponent<EnemyControl>();
        gameManager = GameObject.Find("GameManager");
        waveSystem = gameManager.GetComponent<WaveSystem>();
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(float damageAmount) // système de prise de dommages de l'ennemi
    {
        enemyControl.health -= damageAmount;

        if (enemyControl.health <= 0)
        {
            waveSystem.enemyCount--;
            Destroy(gameObject);
        }
    }


}
