using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // R�f�rence au gestionnaire de dialogue que vous avez cr��.
    public DialogueDataLoader dialogueDataLoader;
    public DialogueManager dialogueManager;

    // Appel� lorsque le bouton est cliqu�.
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
            Debug.LogError("R�f�rence au gestionnaire de dialogue non d�finie. Assurez-vous de l'attribuer dans l'inspecteur Unity.");
        }

    }
}
