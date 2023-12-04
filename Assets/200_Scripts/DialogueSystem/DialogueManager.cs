using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[Serializable]
public class Dialogue
{
    public int dialogueID;
    public string character;
    public string text;
    public string response1;
    public string response2;
    public string response3;
    public int nextDialogueID1;
    public int nextDialogueID2;
    public int nextDialogueID3;
    public int nextDialogueID4;

    public Dialogue(int id, string chara, string txt, string resp1, string resp2, string resp3, int next1, int next2, int next3, int next4)
    {
        dialogueID = id;
        character = chara;
        text = txt;
        response1 = resp1;
        response2 = resp2;
        response3 = resp3;
        nextDialogueID1 = next1;
        nextDialogueID2 = next2;
        nextDialogueID3 = next3;
        nextDialogueID4 = next4;
    }
}

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI character; // Référence à l'objet TextMeshPro pour afficher quel PNJ parle.
    public TextMeshProUGUI dialogueText; // Référence à l'objet TextMeshPro pour afficher le texte du dialogue.
    public Button responseButton1; // Référence au bouton de réponse 1.
    public Button responseButton2; // Référence au bouton de réponse 2.
    public Button responseButton3; // Référence au bouton de réponse 3.

    public DialogueDataLoader dialogueDataLoader;
    private int currentDialogueIndex = 0; // Indice du dialogue en cours.

    private void Start()
    {
        dialogueDataLoader = FindObjectOfType<DialogueDataLoader>();
    }

    private void Update()
    {
        if (!responseButton1.IsActive() && !responseButton2.IsActive() && !responseButton3.IsActive())
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                int nextDialogueID = dialogueDataLoader.dialogues[currentDialogueIndex].nextDialogueID4;
                currentDialogueIndex = FindDialogueIndexByID(nextDialogueID);

                // Afficher le prochain dialogue.
                if (nextDialogueID != -1)
                    ShowDialogue(dialogueDataLoader.dialogues[currentDialogueIndex]);
                else
                {
                    Debug.Log("Je sors de la boîte de dialogue");
                    dialogueComparator.text = string.Empty;
                }
            }
        }
    }

    public TextMeshProUGUI dialogueComparator;
    public void ShowDialogue(Dialogue dialogue)
    {
        character.text = dialogue.character;
        dialogueText.text = dialogue.text;

        if (dialogue.response1 != string.Empty)
        {
            if (dialogueComparator != null && dialogue.response1 != dialogueComparator.text)
            {
                ColorBlock cb = responseButton1.colors;
                cb.normalColor = Color.white;
                cb.highlightedColor = new Color(245, 245, 245);
                responseButton1.colors = cb;
                responseButton2.colors = cb;
                responseButton3.colors = cb;
            }
            responseButton1.gameObject.SetActive(true);
            responseButton1.GetComponentInChildren<TextMeshProUGUI>().text = dialogue.response1;
        }
        else
        {
            responseButton1.gameObject.SetActive(false);
        }

        if (dialogue.response2 != string.Empty)
        {
            responseButton2.gameObject.SetActive(true);
            responseButton2.GetComponentInChildren<TextMeshProUGUI>().text = dialogue.response2;
        }
        else
        {
            responseButton2.gameObject.SetActive(false);
        }

        if (dialogue.response3 != string.Empty)
        {
            responseButton3.gameObject.SetActive(true);
            responseButton3.GetComponentInChildren<TextMeshProUGUI>().text = dialogue.response3;
        }
        else
        {
            responseButton3.gameObject.SetActive(false);
        }
    }

    public void SelectResponse(int responseID)
    {
        if (responseID == 1)
        {
            dialogueComparator.text = dialogueDataLoader.dialogues[currentDialogueIndex].response1;
            ColorBlock cb = responseButton1.colors;
            cb.normalColor = Color.gray;
            cb.highlightedColor = Color.gray;
            responseButton1.colors = cb;
            int nextDialogueID = dialogueDataLoader.dialogues[currentDialogueIndex].nextDialogueID1;
            currentDialogueIndex = FindDialogueIndexByID(nextDialogueID);
        }

        else if (responseID == 2)
        {
            dialogueComparator.text = dialogueDataLoader.dialogues[currentDialogueIndex].response1;
            ColorBlock cb = responseButton2.colors;
            cb.normalColor = Color.gray;
            cb.highlightedColor = Color.gray;
            responseButton2.colors = cb;
            int nextDialogueID = dialogueDataLoader.dialogues[currentDialogueIndex].nextDialogueID2;
            currentDialogueIndex = FindDialogueIndexByID(nextDialogueID);
        }

        else if (responseID == 3)
        {
            dialogueComparator.text = dialogueDataLoader.dialogues[currentDialogueIndex].response1;
            ColorBlock cb = responseButton3.colors;
            cb.normalColor = Color.gray;
            cb.highlightedColor = Color.gray;
            responseButton3.colors = cb;
            int nextDialogueID = dialogueDataLoader.dialogues[currentDialogueIndex].nextDialogueID3;
            currentDialogueIndex = FindDialogueIndexByID(nextDialogueID);
        }
            // Afficher le prochain dialogue.
            ShowDialogue(dialogueDataLoader.dialogues[currentDialogueIndex]);
    }

    // Méthode pour trouver l'indice d'un dialogue par son ID.
    private int FindDialogueIndexByID(int id)
    {
        int newID = 0;
        for (int i = 0; i < dialogueDataLoader.dialogues.Count; i++)
        {
            if (dialogueDataLoader.dialogues[i].dialogueID == id)
            {
                newID = i;
                break;
            }
                
            else
            {
                newID = -1; // Dialogue introuvable.
            }
        }
        return newID;
    }
}
