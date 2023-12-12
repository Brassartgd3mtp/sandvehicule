using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public GameObject quest1, quest2, quest3;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void LoadQuest1()
    {
        quest1.SetActive(true);
    }

    public void LoadQuest2() 
    {
        quest2.SetActive(true);
    }

    public void LoadQuest3() 
    
    { 
        quest3.SetActive(true);
    }
}
