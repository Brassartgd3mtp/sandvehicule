using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest3 : MonoBehaviour
{
    public QuestManager questManager;

    private int nbrPishkars;

    public TextMeshProUGUI text_Part1, textPart2;

    public void Start()
    {
        questManager = QuestManager.Instance;
    }

    public void StartPart1()
    {
        text_Part1.text = $"Pêhcher le gros Pishkars {nbrPishkars} / 1";
        text_Part1.enabled = true;
    }
    public void EndPart1()
    {
        text_Part1.enabled = false;
        StartPart2();
    }


    public void StartPart2() 
    {
        textPart2.text = "Rapporter le gros Pishkar au laboratoire d'Eugénie";
        textPart2.enabled = true;
    }

    public void EndPart2()
    {
        textPart2.enabled= false;
    }
}
