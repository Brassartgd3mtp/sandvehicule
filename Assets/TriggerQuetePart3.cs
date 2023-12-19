using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuetePart3 : MonoBehaviour
{
    public GameObject actualQuest, nextQuest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ThirdPerson thirdPerson))
        {
            actualQuest.SetActive(false);
            nextQuest.SetActive(true);
        }

    }
}
