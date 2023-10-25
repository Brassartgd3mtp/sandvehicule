using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // R�f�rence au gestionnaire de dialogue que vous avez cr��.
    public DialogueManager dialogueManager;

    // Appel� lorsque le bouton est cliqu�.
    public void StartDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

        if (dialogueManager != null)
        {
            List<Dialogue> dialogues = dialogueManager.dialogues;

            Debug.Log(dialogues);

            if (dialogues.Count > 0)
            {
                dialogueManager.ShowDialogue(dialogues[0]);
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
