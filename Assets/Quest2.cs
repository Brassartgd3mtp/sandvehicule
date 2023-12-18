using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest2 : MonoBehaviour
{
    public TextMeshProUGUI text_Part1, text_Part2, text_Part3;
    private QuestManager questManager;

    public void Start()
    {
        questManager =QuestManager.Instance;

        //text_Part1 = GetComponent<TextMeshProUGUI>();
        //text_Part2 = GetComponent<TextMeshProUGUI>();
        //text_Part3 = GetComponent<TextMeshProUGUI>();
    }

    public void UpdtaQuest()
    {
        
    }

    public void StartPart1()
    {
        text_Part1.text = "Parler à Cheyenne au hangar";
        text_Part1.enabled = true;
    }

    public void EndPart1()
    {
        text_Part1. enabled = false;
        StartPart2();
    }

    public void StartPart2()
    {
        text_Part2.text = "Casser les rochers qui maintiennes la carcasse";
        text_Part2.enabled = true;
    }

    public void EndPart2()
    {
        text_Part2.enabled = false;
        StartPart3();
    }

    public void StartPart3()
    {
        text_Part3.text = "Explorer l'autre côté de la corniche";   
        text_Part3.enabled = true;
    }

    public void EndPart3()
    {
        text_Part3.enabled = false;
    }

}
