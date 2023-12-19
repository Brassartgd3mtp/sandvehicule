using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PygonattPattern : MonoBehaviour
{
    public Animator animatorPygonatt;
    void Start()
    {
        animatorPygonatt = GetComponent<Animator>();
    }

    void Update()
    {
        if (animatorPygonatt != null)
        {
            bool boolJump = animatorPygonatt.GetBool("Jump");
            if (!boolJump)
            {
                Debug.Log("Le booléen est faux !");
            }
            else if(boolJump)
            {
                Debug.Log("Le booléen est vrai !");
            }
        }
    }
}
