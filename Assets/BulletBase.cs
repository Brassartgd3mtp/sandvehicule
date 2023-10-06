using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : BulletParent
{
    [SerializeField] Rigidbody rb;
    [SerializeField] public GameObject ShootPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ShootPos = GameObject.FindGameObjectWithTag("CanonPos");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
