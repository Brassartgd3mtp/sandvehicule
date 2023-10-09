using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{

    public GameObject shootingPos;
    public GameObject BaseProjectile;
    public PlayerStates playerStates;

    public int speed;

    void Start()
    {
        playerStates = GetComponent<PlayerStates>();
    }

    void Update()
    {
        
    }

    public void BasicShoot(InputAction.CallbackContext context) //Méthode qui permet de tirer
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                if (playerStates.states == PlayerStates.States.Fifhting) // permet de tirer uniquement pendant le mode de combat 
                {
                    Instantiate(BaseProjectile, shootingPos.transform.position, shootingPos.transform.rotation);
                }
                
                //projectile.transform.position += transform.forward * Time.deltaTime * speed;
                break;
        }
    }
}
