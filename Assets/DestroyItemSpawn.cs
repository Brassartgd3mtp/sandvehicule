using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItemSpawn : MonoBehaviour
{
    public harpoonBrain harpoonBrain;
    public GameObject itemToSpawn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Harpoon")
        {
            harpoonBrain = collision.gameObject.GetComponent<harpoonBrain>();
            if (harpoonBrain.isHarpoonExplosive)
            {
                Instantiate(itemToSpawn, this.transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

}
