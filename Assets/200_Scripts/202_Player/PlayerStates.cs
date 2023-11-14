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

    public Image UITurret, UIHarpoon;

    void Awake()
    {
        states = States.Exploring;
        AttackManager = GetComponent<AttackManager>();
    }

    // permet de changer de states pour les tests avec les touches "& et é"
    public void ChangeStateForFighting()
    {
        states = PlayerStates.States.Fifhting;
        //CameraScript.CameraForFighting();
        projectileProjection.Play();
        UIHarpoon.color = new Color(1, 1, 1, 0.5f);
        UITurret.color = new Color(1, 1, 1, 1);
    }

    public void ChangeStateForExploring()
    {
        states = PlayerStates.States.Exploring;
        //CameraScript.CameraForExploring();
        projectileProjection.Stop(); projectileProjection.Clear();
        UIHarpoon.color = new Color(1, 1, 1, 1);
        UITurret.color = new Color(1, 1, 1, 0.5f);
    }
}

