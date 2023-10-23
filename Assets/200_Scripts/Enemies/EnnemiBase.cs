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

    }
    void FixedUpdate()
    {
        if (atRangeOfPlayer == false)
        {
            rb.velocity = transform.forward * enemyControl.speed;
            transform.LookAt(player.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // récupère le script du player à la collision pour lui infliger déclencher la coroutine
        {
            playerTakeDamage = collision.gameObject.GetComponent<PlayerTakeDamage>();
            Debug.Log("touched");
            atRangeOfPlayer = true;
            StartCoroutine(isAttacking());
        }
    }

    public IEnumerator isAttacking() // Déclenche la coroutine de dégat et la vitesse d'attaque de l'ennemi
    {
        do
        {
            playerTakeDamage.TakeDamage(enemyControl.damage);
            yield return new WaitForSeconds(1 / enemyControl.attackSpeed);
        } while (atRangeOfPlayer == true);
    }


}
