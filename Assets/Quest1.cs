using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest1 : MonoBehaviour
{
    public TextMeshProUGUI Text_Salasand;
    public TextMeshProUGUI Text_Auxyls;
    public TextMeshProUGUI Text_Part2;

    public DialogueWyatt dialogueWyatt;

    private int nbrSalasand, nbrAuxyls;

    public bool questIsCompleted;

    private QuestManager questManager;

    public void Start()
    {
        questManager = QuestManager.Instance;
        UpdateQuest();
        StartPart1();
    }

    public void UpdateQuest()
    {

        Text_Salasand.text = $"Pêcher 5 Salasands {nbrSalasand}/ 5";
        Text_Auxyls.text = $" Récupérer 3 Auxyls {nbrAuxyls}/ 3";
        
        if (nbrSalasand == 5 && nbrAuxyls == 3)
        {
            QuestItem.OnQuestItemPickUp -= AddItem;

            StartPart2();       
        }
    }
    public void StartPart1()
    {
        QuestItem.OnQuestItemPickUp += AddItem;
        Text_Salasand.enabled = true;
        Text_Auxyls.enabled = true;
    }

    private void AddItem(int _itemId)
    {
        if(_itemId == 3)
        {
            AddSalasand();
        }
        else if(_itemId == 7)
        {
            AddAuxyls();
        }
    }
    public void AddSalasand()
    {
        if (gameObject.activeInHierarchy)
        {
            nbrSalasand++;
            UpdateQuest();
        }
    }

    public void AddAuxyls()
    {
        if (gameObject.activeInHierarchy)
        {
            nbrAuxyls++;
            UpdateQuest();
        }
    }
    
    public void StartPart2()
    {
        Text_Salasand.enabled = false;
        Text_Auxyls.enabled = false;
        Text_Part2.text = "Donner les Pishkars et les plantes à Wyatt";
        Text_Part2.gameObject.SetActive(true);
        dialogueWyatt.EnableColliderForSpeaking();
    }
}
