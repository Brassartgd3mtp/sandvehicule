using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionManager : MonoBehaviour
{
    public ThirdPerson thirdPerson;
    public List<GameObject> text;
    public Button button;
    public CinemachineVirtualCamera WyattCamera;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        text[0].SetActive(true);
    }

    public void Update()
    {
        
        if (text.Count == 0)
        {
            WyattCamera.Priority = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Destroy(gameObject);
        }

        if (text.Count <= 14)
        {
            button.image.color = new Color(1f, 1f, 1f,0);
        }

    }

    public void PassNextDialogue()
    {
        Debug.Log("text");
        text[0].SetActive(false);
        text.Remove(text[0]);
        if (text.Count >= 1 ) 
        {
            text[0].SetActive(true);
        }
    }
}
