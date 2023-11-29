using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Salasand : MonoBehaviour
{
    public Vector3 startLocation;
    public Vector3 nextJumpLocation;

    public bool canMove;
    public bool animationIsPlaying;

    public float moveSpeed;

    public float jumpingOffset;
    public float animationTime = 3;

    public Animator animator;

    public void Awake()
    {

    }

    public void Start()
    {

    }
}
