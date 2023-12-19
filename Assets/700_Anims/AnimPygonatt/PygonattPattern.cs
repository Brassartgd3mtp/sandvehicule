using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PygonattPattern : FishBehavior
{

    public Animator jumpAnimator;
    //[SerializeField] private Transform child;
    public List<GameObject> Carapace;

    public override void CatchItem(Transform _parent)
    {
        if (!isReadyToBeCaught)
        {
            if (Carapace.Count > 0)
            {
                Destroy(Carapace[0]);
                Carapace.RemoveAt(0);
            }
            if (Carapace.Count == 0)
            {
                isReadyToBeCaught = true;
                //transform.localPosition = Vector3.zero;
            }
        }
        Destroy(jumpAnimator);
        //child.localPosition = Vector3.zero;
        GetComponent<SphereCollider>().isTrigger = true;
        base.CatchItem(_parent);
        transform.localPosition.Set(0, 0, 0);// = Vector3.zero;
    }

    void Update()
    {
        //if (animatorPygonatt != null)
        //{
        //    bool boolJump = animatorPygonatt.GetBool("Jump");
        //    if (!boolJump)
        //    {
        //        Debug.Log("Le booléen est faux !");
        //    }
        //    else if (boolJump)
        //    {
        //        Debug.Log("Le booléen est vrai !");
        //    }
        //}
    }
}
