using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public static event Action<int> OnQuestItemPickUp;

    public void UpdateQuest(int ID)
    {
        OnQuestItemPickUp?.Invoke(ID);
    }
}
