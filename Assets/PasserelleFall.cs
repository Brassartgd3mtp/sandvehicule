using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasserelleFall : MonoBehaviour
{
    public GameObject rock1, rock2, rock3;
    public GameObject actualQuest, nextQuest; 

    public bool ActivateAnim;

    public Animator animator;
    public void Update()
    {
        if (rock1 == null && rock2 == null && rock3 == null)
        {
            ActivateAnim = true;
            actualQuest.SetActive(false);
            nextQuest.SetActive(true);
        }

        if (ActivateAnim)
        {
            animator.SetBool("isActivate", true);
            ActivateAnim = false;
        }
    }

}
