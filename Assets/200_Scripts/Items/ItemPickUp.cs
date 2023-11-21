using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadius = 1f;
    public ItemSO itemSO;

    private SphereCollider myCollider;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.radius = PickUpRadius;
    }

    public void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            var inventory = collision.transform.GetComponent<PlayerInventoryHolder>();

            if (!inventory) return;

            if (inventory.AddToInventory(itemSO, 1))
            {
                Destroy(this.gameObject);
            }
        }

    }
}
