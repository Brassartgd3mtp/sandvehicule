using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationOffset : MonoBehaviour
{
    public Animator anim;
    float randomOffset;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        randomOffset = Random.Range(0f, 3f);

        anim.Play("Salasand_Jump", 0, randomOffset);
    }
}
