using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : BulletParent
{
    [SerializeField] Rigidbody rb;
    [SerializeField] ParticleSystem sparkParticuleBase;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        damageAmount = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnnemiParent>(out EnnemiParent enemyComponent)) // je récupère le composant de l'ennemi pour lui enlever le montant de damage
        {
            enemyComponent.TakeDamage(damageAmount);
            Instantiate(sparkParticuleBase, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
