using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiParent : MonoBehaviour
{
    public EnemyControl enemyControl;

    public UnityEngine.GameObject gameManager;
    public WaveSystem waveSystem;

    public bool canAttack;
    public float coolDown;

    public Rigidbody rb;

    void Awake()
    {
        enemyControl = GetComponent<EnemyControl>();
        gameManager = UnityEngine.GameObject.Find("GameManager");
        waveSystem = gameManager.GetComponent<WaveSystem>();
        rb = GetComponent<Rigidbody>();
        coolDown = 1 / enemyControl.attackSpeed;
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
