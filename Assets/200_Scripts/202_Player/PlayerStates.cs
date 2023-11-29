using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerStates : MonoBehaviour
{

    public CameraScript CameraScript;
    public AttackManager AttackManager;
    public enum States { Exploring, Fifhting, InBase }

    public States states;
    public ParticleSystem projectileProjection;

    void Awake()
    {
        states = States.Exploring;
        AttackManager = GetComponent<AttackManager>();
    }
    
    public void ChangeStateForFighting() // permet de changer de states pour les tests avec les touches "& et é"
    {
        states = PlayerStates.States.Fifhting;
        //CameraScript.CameraForFighting();
    }

    public void ChangeStateForExploring()
    {
        states = PlayerStates.States.Exploring;
        //CameraScript.CameraForExploring();
    }
}

