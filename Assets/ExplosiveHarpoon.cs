using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveHarpoon : MonoBehaviour
{
    [SerializeField] harpoonBrain harpoonBrain;
    [SerializeField] ParticleSystem explosion;

    public void Awake()
    {
        harpoonBrain = GetComponent<harpoonBrain>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (harpoonBrain.isHarpoonExplosive && collision.gameObject)
        {
            explosion.transform.position = harpoonBrain.targetObject;
            explosion.Play();
            PlaySoundExplosion();
            if (collision.gameObject.CompareTag("Destructible"))
            {

                Destroy(collision.gameObject);
            }
        }
    }

    private void PlaySoundExplosion()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        AudioManager.Instance.PlaySound(26, audioSource);
    }
}
