using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadius = 1f;
    public ItemSO itemSO;

    public GameObject player;

    private SphereCollider myCollider;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myCollider = GetComponent<SphereCollider>();
        myCollider.radius = PickUpRadius;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player");
        }
    }

    public void PickUp()
    {
        var inventory = player.GetComponent<PlayerInventoryHolder>();

        if (!inventory) return;

        if (inventory.AddToInventory(itemSO, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
