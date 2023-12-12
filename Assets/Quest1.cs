using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest1 : MonoBehaviour
{
    public TextMeshProUGUI Text_Salasand;
    public TextMeshProUGUI Text_Auxyls;

    private int nbrSalasand, nbrAuxyls;

    private QuestManager questManager;

    public void Start()
    {
        questManager = QuestManager.Instance;
        UpdateQuest();
    }

    public void UpdateQuest()
    {
            Text_Salasand.text = $"Pêcher 5 Salasands {nbrSalasand}/ 5";
            Text_Auxyls.text = $" Récupérer 3 Auxyls {nbrAuxyls}/ 3";
    }

    public void AddSalasand()
    {
        if (questManager.quest1.activeInHierarchy)
        {
            nbrSalasand++;
            UpdateQuest();
        }

    }

    public void AddAuxyls()
    {
        if (questManager.quest1.activeInHierarchy)
        {
        nbrAuxyls ++;
        UpdateQuest();
        }
    }
}
