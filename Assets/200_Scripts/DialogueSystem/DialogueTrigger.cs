using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Référence au gestionnaire de dialogue que vous avez créé.
    public DialogueManager dialogueManager;

    // Appelé lorsque le bouton est cliqué.
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
            Debug.LogError("Référence au gestionnaire de dialogue non définie. Assurez-vous de l'attribuer dans l'inspecteur Unity.");
        }

    }
}
