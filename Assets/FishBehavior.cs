using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class FishBehavior : ItemParent
{
    public bool isReadyToBeCaught;


    public override void CatchItem(Transform _parent)
    {
        if (isReadyToBeCaught) 
        {
            Debug.Log("joue");


            base.CatchItem(_parent);
            if (TryGetComponent(out Animator animator))
            {
                animator.enabled = false;
            }
        } 

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ThirdPerson thirdPerson))
        {
            if (TryGetComponent(out QuestItem questItem))
            {
                questItem.UpdateQuest(itemSO.ID);
            }
        }
    }
}
