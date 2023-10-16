using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    public Stats stats;


    public GameObject shootingPos;
    public GameObject BaseProjectile;
    public PlayerStates playerStates;

    public bool isShooting;
    public float cooldownAttack;

    public int speed;

    void Start()
    {
        cooldownAttack = 0;
        playerStates = GetComponent<PlayerStates>();
        stats = GetComponent<Stats>();
    }

    void Update()
    {
        // Systeme de CoolDown de tir
        if (isShooting == true && cooldownAttack <= 0) 
        {
            Instantiate(BaseProjectile, shootingPos.transform.position, shootingPos.transform.rotation);
            cooldownAttack = 1 / stats.attackSpeed;
        }
        if (cooldownAttack > 0)
        {
            cooldownAttack -= Time.deltaTime;
        }

    }

    public void BasicShoot(InputAction.CallbackContext context) //Méthode qui permet de tirer
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:

                if (playerStates.states == PlayerStates.States.Fifhting) // permet de tirer uniquement pendant le mode de combat 
                {
                    isShooting = true;
                }
                
                //projectile.transform.position += transform.forward * Time.deltaTime * speed;
                break;
            case InputActionPhase.Canceled:
                if (playerStates.states == PlayerStates.States.Fifhting)
                {
                    isShooting = false;
                }
                break;

        }
    }

}
