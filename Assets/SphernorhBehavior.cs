using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphernorhBehavior : MonoBehaviour
{
    public GameObject Carapace;
    public harpoonBrain harpoonBrain;

    public FishBehavior fishBehavior;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Harpoon"))
        {
            harpoonBrain = collision.gameObject.GetComponent<harpoonBrain>();

            if (harpoonBrain.isHarpoonExplosive)
            {
                Destroy(Carapace);
                fishBehavior.isReadyToBeCaught = true;
            }
        }
    }
}
