using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Salasand : MonoBehaviour
{
    public Vector3 startLocation;
    public Vector3 nextJumpLocation;

    public bool isPlaying;
    public bool isLerping;
    public bool animationIsPlaying;

    public float moveSpeed;

    public float jumpingOffset;
    public float animationTime = 3;

    public Animation animation;

    public void Awake()
    {
        startLocation = transform.position;
    }

    public void Start()
    {
     
        isLerping = true;
        NewJumpLocation();
        animation = GetComponent<Animation>();
    }

    public void Update()
    {
        if (isLerping)
        {
            transform.position = Vector3.Lerp(transform.position, nextJumpLocation, moveSpeed * Time.deltaTime);
        }

        if (transform.position == nextJumpLocation)
        {
            jumpingOffset -=Time.deltaTime;
            isLerping = false;
            NewJumpLocation();
        }
        if (jumpingOffset <= 0)
        {
            animation.Play("Salasand_Jump");
            animationIsPlaying = true; ;
            jumpingOffset = 3f;
        }
        if (animationIsPlaying)
        {
            animationTime -= Time.deltaTime;
        }
        if (animationTime <= 0) 
        {
            animationIsPlaying = false;
            isLerping = true;
            animationTime = 3;
        }
    }

    public void NewJumpLocation()
    {
        nextJumpLocation = startLocation + new Vector3(Random.Range(-3f,3f), 0, Random.Range(-3f, 3f));
    }

    public void MoveToNextLocation()
    {
        //float step = moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, nextJumpLocation,step);
        
    }
}
