using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Référence au gestionnaire de dialogue que vous avez créé.
    public DialogueDataLoader dialogueDataLoader;
    public DialogueManager dialogueManager;

    // Appelé lorsque le bouton est cliqué.
    public void StartDialogue()
    {
        dialogueDataLoader = FindObjectOfType<DialogueDataLoader>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        if (dialogueDataLoader != null)
        {
            Debug.Log(dialogueDataLoader.dialogues);

            if (dialogueDataLoader.dialogues.Count > 0)
            {
                dialogueManager.ShowDialogue(dialogueDataLoader.dialogues[0]);
            }

            else
            {
                Debug.LogError("Aucun dialogue n'est disponible.");
            }
        }
        else
        {
            Debug.LogError("Référence au gestionnaire de dialogue non définie. Assurez-vous de l'attribuer dans l'inspecteur Unity.");
        }

    }
}
