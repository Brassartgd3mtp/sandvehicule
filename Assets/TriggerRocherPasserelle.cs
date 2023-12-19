using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRocherPasserelle : MonoBehaviour
{
    public List<GameObject> text;

    public float timer = 4;

    public bool isActived = false;

    public GameObject CanvaToActivate;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ThirdPerson thirdPerson))
        {
            if (!isActived)
            {
                isActived = true;
                CanvaToActivate.SetActive(true);
                text[0].SetActive(true);
            }

        }
    }

    public void Update()
    {
        if (text.Count == 0)
        {
            Destroy(gameObject);
        }

        if (isActived)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            PassNextDialogue();
            timer = 4;
        }

    }

    public void PassNextDialogue()
    {
        Debug.Log("text");
        text[0].SetActive(false);
        text.Remove(text[0]);
        if (text.Count >= 1)
        {
            text[0].SetActive(true);
        }
    }
}
