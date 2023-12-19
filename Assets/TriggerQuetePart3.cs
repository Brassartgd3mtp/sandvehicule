using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuetePart3 : MonoBehaviour
{
    public GameObject canvaQuest;
    public GameObject actualQuest, nextQuest;

    public List<GameObject> text;

    public float timer = 4;

    public bool isActived = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ThirdPerson thirdPerson))
        {
            if(!isActived) 
            {
                isActived = true;
                actualQuest.SetActive(false);
                canvaQuest.SetActive(true);
                text[0].SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }

        }
    }

    public void Update()
    {
        if (text.Count == 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            nextQuest.SetActive(true);
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
