using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DialogueDataLoader : MonoBehaviour
{
    public TextAsset tsvFile;
    public List<Dialogue> dialogues = new List<Dialogue>(); // Liste pour stocker les dialogues.

    private void Start()
    {
        LoadDialogueData();
    }

    private void LoadDialogueData()
    {
        string[] lines = tsvFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split('\t');
            if (values.Length == 10)
            {
                int dialogueID = SafeParseInt(values[0]);
                string character = values[1];
                string text = values[2];
                string response1 = values[3];
                string response2 = values[4];
                string response3 = values[5];
                int nextDialogueID1 = SafeParseInt(values[6]);
                int nextDialogueID2 = SafeParseInt(values[7]);
                int nextDialogueID3 = SafeParseInt(values[8]);
                int nextDialogueID4 = SafeParseInt(values[9]);

                Dialogue dialogue = new Dialogue(dialogueID, character, text, response1, response2, response3, nextDialogueID1, nextDialogueID2, nextDialogueID3, nextDialogueID4);
                dialogues.Add(dialogue);
            }
            else
            {
                Debug.LogError("Erreur de format dans le CSV à la ligne " + i);
            }
        }
    }

    private int SafeParseInt(string input)
    {
        int result = 0;
        if (int.TryParse(input, out result) && input != "-1")
        {
            return result;
        }
        else
        {
            // Gérer la validation ou l'erreur ici (par exemple, journalisation, renvoyer une valeur par défaut, etc.).
            //Debug.LogWarning("La valeur '" + input + "' n'est pas un entier valide.");
            return -1;
        }
    }
}
