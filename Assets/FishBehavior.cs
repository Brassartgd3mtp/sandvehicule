using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishBehavior : ItemParent
{
    public bool isReadyToBeCaught;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void CatchItem(Transform _parent)
    {
        if (isReadyToBeCaught) 
        {
            Destroy(animator);
            base.CatchItem(_parent);
            //transform.localPosition = Vector3.zero;
        } 

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent(out ThirdPerson thirdPerson))
    //    {
    //        if (TryGetComponent(out QuestItem questItem))
    //        {
    //            questItem.UpdateQuest(itemSO.ID);
    //        }
    //    }
    //}
}
