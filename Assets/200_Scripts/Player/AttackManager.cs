using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{

    public GameObject shootingPos;
    public GameObject BaseProjectile;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BasicShoot(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                Instantiate(BaseProjectile, shootingPos.transform.position, shootingPos.transform.rotation);
                
                //projectile.transform.position += transform.forward * Time.deltaTime * speed;
                break;
        }
    }
}
