using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
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

    public Dialogue(int id, string chara, string txt, string resp1, string resp2, string resp3, int next1, int next2, int next3)
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
    }
}

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI character; // R�f�rence � l'objet TextMeshPro pour afficher quel PNJ parle.
    public TextMeshProUGUI dialogueText; // R�f�rence � l'objet TextMeshPro pour afficher le texte du dialogue.
    public Button responseButton1; // R�f�rence au bouton de r�ponse 1.
    public Button responseButton2; // R�f�rence au bouton de r�ponse 2.
    public Button responseButton3; // R�f�rence au bouton de r�ponse 3.

    public List<Dialogue> dialogues; // Liste de dialogues charg�e depuis le fichier externe.
    private int currentDialogueIndex = 0; // Indice du dialogue en cours.

    private void Start()
    {
        // Afficher le premier dialogue.
        ShowDialogue(dialogues[currentDialogueIndex]);
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        character.text = dialogue.character;
        dialogueText.text = dialogue.text;

        if (dialogue.response1 != "")
        {
            responseButton1.gameObject.SetActive(true);
            responseButton1.GetComponentInChildren<Text>().text = dialogue.response1;
        }
        else
        {
            responseButton1.gameObject.SetActive(false);
        }

        if (dialogue.response2 != "")
        {
            responseButton2.gameObject.SetActive(true);
            responseButton2.GetComponentInChildren<Text>().text = dialogue.response2;
        }
        else
        {
            responseButton2.gameObject.SetActive(false);
        }

        if (dialogue.response3 != "")
        {
            responseButton3.gameObject.SetActive(true);
            responseButton3.GetComponentInChildren<Text>().text = dialogue.response3;
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
            int nextDialogueID = dialogues[currentDialogueIndex].nextDialogueID1;
            currentDialogueIndex = FindDialogueIndexByID(nextDialogueID);
        }
        else if (responseID == 2)
        {
            int nextDialogueID = dialogues[currentDialogueIndex].nextDialogueID2;
            currentDialogueIndex = FindDialogueIndexByID(nextDialogueID);
        }
        else if (responseID == 3)
        {
            int nextDialogueID = dialogues[currentDialogueIndex].nextDialogueID3;
            currentDialogueIndex = FindDialogueIndexByID(nextDialogueID);
        }

        // Afficher le prochain dialogue.
        ShowDialogue(dialogues[currentDialogueIndex]);
    }

    // M�thode pour trouver l'indice d'un dialogue par son ID.
    private int FindDialogueIndexByID(int id)
    {
        for (int i = 0; i < dialogues.Count; i++)
        {
            if (dialogues[i].dialogueID == id)
            {
                return i;
            }
        }
        return -1; // Dialogue introuvable.
    }

}
