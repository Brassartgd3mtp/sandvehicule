using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemiBase : EnnemiParent
{
    public UnityEngine.GameObject player;
    public PlayerTakeDamage playerTakeDamage;

    public UnityEngine.GameObject mesh;

    public bool atRangeOfPlayer;



    public void Start()
    {
        enemyControl = GetComponent<EnemyControl>();
        player = UnityEngine.GameObject.FindGameObjectWithTag("Player");
        coolDown = 0;
    }
    void FixedUpdate()
    {

        if (atRangeOfPlayer == false)
        {
            rb.velocity = transform.forward * enemyControl.speed;
            transform.LookAt(player.transform.position);
        }

        if (canAttack == false)
        {
            coolDown -= Time.deltaTime;
        }

        if (coolDown <= 0)
        {
            canAttack = true;
        }
        else canAttack = false;



        if (canAttack == true && atRangeOfPlayer == true)
        {
            DealDamage();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // récupère le script du player à la collision pour lui infliger déclencher la coroutine
        {
            playerTakeDamage = collision.gameObject.GetComponent<PlayerTakeDamage>();
            atRangeOfPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            atRangeOfPlayer = false;
        }
    }

    public void DealDamage() // Déclenche la coroutine de dégat et la vitesse d'attaque de l'ennemi
    {
        playerTakeDamage.TakeDamage(enemyControl.damage);
        canAttack = false;
        coolDown = 1 / enemyControl.attackSpeed;
    }
}
    