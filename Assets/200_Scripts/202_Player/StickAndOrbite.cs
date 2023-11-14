using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAndOrbite : MonoBehaviour
{
    public GameObject ObjectSticked;
    new public Collider collider;
    public Harpoon harpoon;

    public GameObject player;
    public bool isOrbited;

    public float rotationRadius;
    public float angularSpeed;
    public float posX, posZ, angle = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        // Collision avec les objets autour desquels on peut tourner
        if (collision.gameObject.tag == "Orbital")
        {
            Debug.Log("orbiatal");
            ObjectSticked = collision.gameObject;
            collider.enabled = false;
            harpoon.collideSomething = true;
            rotationRadius = Vector3.Distance(player.transform.position, transform.position);
            isOrbited = true;
            Vector3 currentPosition = player.transform.position - transform.position;
            angle = Mathf.Atan2(currentPosition.z, currentPosition.x);
        }
    }

    public void Update()
    {
        if (isOrbited) // Lorsque l'on a harponné un objet qui peut nous faire tourner 
        {
            posX = transform.position.x + Mathf.Cos(angle) * rotationRadius;
            posZ = transform.position.z + Mathf.Sin(angle) * rotationRadius;
            player.transform.position = new Vector3(posX, 0, posZ);
            angle = angle + Time.deltaTime * angularSpeed;

            if (angle >= Mathf.PI) angle = -Mathf.PI;
        }
    }
}
