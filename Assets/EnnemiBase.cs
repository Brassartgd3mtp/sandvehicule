using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBase : EnnemiParent
{
    public float speed;
    public GameObject player;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,speed * Time.deltaTime);
    }
}
