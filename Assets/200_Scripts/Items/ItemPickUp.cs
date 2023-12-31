using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : ItemParent
{
    public float PickUpRadius = 1f;

    public EncyclopediaEntry EncyclopediaEntry;

    public GameObject player;

    //private SphereCollider myCollider;

    [SerializeField] GameObject CanvaItemPicked;
    [SerializeField] GameObject UI_NewItemPicked;



    private void Awake()
    {
        EncyclopediaEntry = GetComponent<EncyclopediaEntry>();
        CanvaItemPicked = GameObject.Find("CanvaRessourceFeedBack");
        //myCollider = GetComponent<SphereCollider>();
        //myCollider.radius = PickUpRadius;
    }

    public void Start()
    {
        player = ThirdPerson.Instance.gameObject;
    }

    public void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    { 
        
        //if (collision.gameObject.tag == "Player" && isGrabed)
        //{
        //    PickUp();
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player" && isGrabed))
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
            
            if (TryGetComponent(out QuestItem questItem))
            {
                questItem.UpdateQuest(itemSO.ID);
            }

            Destroy(this.gameObject);
        }
    }
}
