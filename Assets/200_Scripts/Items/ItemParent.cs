using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParent : MonoBehaviour
{
    public ItemSO itemSO;
    public bool isGrabed;
    public virtual void CatchItem(Transform _parent)
    {   
        isGrabed = true;
        transform.SetParent(_parent, true);
        transform.localPosition = Vector3.zero;
    }
}
