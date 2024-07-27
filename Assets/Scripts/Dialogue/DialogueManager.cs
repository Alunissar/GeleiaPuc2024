using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    public DialogueText dialogueText;
    public GameObject dialogueBox;
    public CharacterSO testChar;
    private List<string> queuedTexts = new List<string>();

    public void Start()
    {
        WriteDialogue(testChar.GetDialoguePrompt(DialogueSO.DialoguePrompt.FIRST_MEETING));
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){NextText();}
    }

    public void WriteDialogue(DialogueSO dialogue)
    {
        queuedTexts.Clear();
        dialogueBox.SetActive(true);
        for(int i = 0; i < dialogue.texts.Length; i++)
        {
            queuedTexts.Add(dialogue.texts[i]);
        }
        NextText();
    }

    public void WriteDialogue(string text)
    {
        dialogueText.WriteText(text);
    }

    public void NextText()
    {
        if(queuedTexts.Count == 0)
        {
            dialogueBox.SetActive(false);
            return;
        }
        WriteDialogue(queuedTexts[0]);
        queuedTexts.RemoveAt(0);
    }
}
