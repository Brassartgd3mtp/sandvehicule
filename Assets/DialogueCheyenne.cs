using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCheyenne : MonoBehaviour
{
    public bool canSpeak;

    public Collider collider;

    public Button button;

    public GameObject UI_Parler;
    public GameObject CanvaQuest;
    public GameObject actualQuest;
    public GameObject NextQuest;

    public harpoonBrain harpoonBrain;
    public CinemachineVirtualCamera CheyenneCamera;

    public List<GameObject> text;

    public bool readyToSpeak;

    public void EnableCollider()
    {
        collider.enabled = true;
    }


    public void Update()
    {
        if (text.Count <= 0)
        {
            EndDialogue();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (readyToSpeak && other.TryGetComponent(out ThirdPerson thirdPerson))
        {
            UI_Parler.SetActive(true);
            canSpeak = true;
        }
    }
    
    private void OnTriggerExit(Collider other) 
    {
        UI_Parler.SetActive(false);
    }

    public void StartDialogue2Cheyenne()
    {
        Cursor.lockState = CursorLockMode.None;
        actualQuest.SetActive(false);
        CanvaQuest.SetActive(true);
        CheyenneCamera.Priority = 15;
        if (text[0] != null)
        {
            text[0].SetActive(true);
        }

    }

    public void EndDialogue()
    {
        harpoonBrain.isHarpoonExplosive = true;
        NextQuest.SetActive(true);
        CheyenneCamera.Priority = 0;
        Destroy(CanvaQuest);
        this.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PassNextDialogue()
    {
        Debug.Log("là");
        text[0].SetActive(false);
        text.Remove(text[0]);
        if (text.Count >= 1)
        {
            text[0].SetActive(true);
        }
    }
}
