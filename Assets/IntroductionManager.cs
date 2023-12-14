using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionManager : MonoBehaviour
{
    public ThirdPerson thirdPerson;
    public List<GameObject> text;
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        text[0].SetActive(true);
    }

    public void Update()
    {
        
        if (text.Count == 0)
        {
            Destroy(gameObject);
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
