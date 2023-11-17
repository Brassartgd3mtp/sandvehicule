using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFighting : MonoBehaviour
{
    public bool isMoving;
    private Vector3 movement;

    public Stats stats;
    public InputManagerFighting inputManagerFighting;

    public void Awake()
    {
        stats = GetComponent<Stats>();
    }
    void FixedUpdate()
    {
        MovePlayer();
    }
    public void MovePlayer()
    {
        movement = new Vector3(inputManagerFighting.inputX, 0f, inputManagerFighting.inputY);

        if (isMoving == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.10f);
        }

        transform.Translate(movement * stats.maxSpeed * Time.deltaTime, Space.World);
    }
}
