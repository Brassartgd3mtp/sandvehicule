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
        if (harpoonBrain.isHarpoonExplosive)
        {
            if (collision.gameObject.CompareTag("Destructible"))
            {
                explosion.transform.position = harpoonBrain.targetObject;
                explosion.Play();
                Destroy(collision.gameObject);
            }
        }
    }
}
