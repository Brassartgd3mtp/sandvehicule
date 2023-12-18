using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SphernorhBehavior : MonoBehaviour
{
    public GameObject Carapace;
    public harpoonBrain harpoonBrain;

    public FishBehavior fishBehavior;

    public SplineAnimate splineAnimate;

    public Collider triggerItem;

    void Start()
    {
        splineAnimate = GetComponent<SplineAnimate>();
        triggerItem = GetComponent<Collider>();
        triggerItem.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Harpoon") && fishBehavior.isReadyToBeCaught)
        {
            Destroy(splineAnimate);
            triggerItem.enabled = true;
        }

        if (collision.gameObject.CompareTag("Harpoon"))
        {
            harpoonBrain = collision.gameObject.GetComponent<harpoonBrain>();

            if (harpoonBrain.isHarpoonExplosive)
            {
                Destroy(Carapace);
                fishBehavior.isReadyToBeCaught = true;
                PlayDestroyArmorSound();
            }
        }
    }

    private void PlayDestroyArmorSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        AudioManager.Instance.PlaySound(32, audioSource);
    }
}
