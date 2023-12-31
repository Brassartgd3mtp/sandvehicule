using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    public Stats stats;


    public UnityEngine.GameObject shootingPos;
    public UnityEngine.GameObject BaseProjectile;
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

    public void BasicShoot(InputAction.CallbackContext context) //M�thode qui permet de tirer
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:// permet de tirer uniquement pendant le mode de combat 
                    isShooting = true;
                break;
            
            case InputActionPhase.Canceled:
                    isShooting = false;
                break;

        }
    }

}
