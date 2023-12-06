using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadius = 1f;

    public ItemSO itemSO;
    public EncyclopediaEntry EncyclopediaEntry;

    public GameObject player;

    private SphereCollider myCollider;

    [SerializeField] GameObject CanvaItemPicked;
    [SerializeField] GameObject UI_NewItemPicked;

    [SerializeField] bool isGrabed;


    private void Awake()
    {
        EncyclopediaEntry = GetComponent<EncyclopediaEntry>();
        CanvaItemPicked = GameObject.Find("CanvaRessourceFeedBack");
        myCollider = GetComponent<SphereCollider>();
        myCollider.radius = PickUpRadius;
    }

    public void Start()
    {
        player = ThirdPerson.Instance.gameObject;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Harpoon")
        {
            isGrabed =true;
        }
        if (collision.gameObject.tag == "Player" && isGrabed)
        {
            PickUp();
        }
    }

    public void PickUp()
    {
        EncyclopediaEntry.InitializeEntry(gameObject);

        var inventory = player.GetComponent<PlayerInventoryHolder>();

        if (!inventory) return;

        if (inventory.AddToInventory(itemSO, 1))
        {
            Instantiate(UI_NewItemPicked, CanvaItemPicked.transform);

            Destroy(this.gameObject);
        }
    }
}
