using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class DialogueWyatt : MonoBehaviour
{
    public new Collider collider;
    public GameObject UI_Parler;
    public QuestManager questManager;

    public CinemachineVirtualCamera WyattCamera;

    public Button button;

    public Quest1 quest1;

    public ThirdPerson thirdPerson;

    public bool canSpeak;

    public List<GameObject> text;

    public GameObject CanvaQuest;
    public GameObject actualQuest;
    public GameObject nextQuest;


    public DialogueCheyenne dialogueCheyenne;

    public void Update()
    {
        if (text.Count == 0)
        {
            dialogueCheyenne.readyToSpeak = true;
            dialogueCheyenne.collider.enabled = true;
            canSpeak = false;
            WyattCamera.Priority = 0;
            nextQuest.SetActive(true);
        }
    }
    public void PassNextDialogue()
    {
        text[0].SetActive(false);
        text.Remove(text[0]);
        if (text.Count >= 1)
        {
            text[0].SetActive(true); 

        }
    }

    public void EndDialogue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(CanvaQuest);
        this.enabled = false;
    }

    public void EnableColliderForSpeaking()
    {
        collider.enabled = true;
        canSpeak = true;
    }

    public void StartDialogue2Wyatt()
    {
        actualQuest.SetActive(false);
        CanvaQuest.SetActive(true);
        if (text[0] != null) 
        {
            text[0].SetActive(true);
        }
        Cursor.lockState = CursorLockMode.None;
        WyattCamera.Priority = 15;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ThirdPerson thirdPerson))
        {
            canSpeak = true;
            UI_Parler.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out ThirdPerson thirdPerson)) 
        {
            UI_Parler.SetActive(false);
        }
    }
}
