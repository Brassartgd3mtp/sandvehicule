using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemiBase : EnnemiParent
{
    public float speed;
    public GameObject player;
    public PlayerTakeDamage playerTakeDamage;

    public Rigidbody rb;


    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (atRangeOfPlayer == false)
        {
            rb.velocity = transform.forward * speed;
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
            playerTakeDamage.TakeDamage(Damage);
            yield return new WaitForSeconds(1 / attackSpeed);
        } while (atRangeOfPlayer == true);
    }
}
