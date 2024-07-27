using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    public DialogueText DialogueText;
    public GameObject DialogueBox;
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
        DialogueBox.SetActive(true);
        for(int i = 0; i < dialogue.texts.Length; i++)
        {
            queuedTexts.Add(dialogue.texts[i]);
        }
        NextText();
    }

    public void WriteDialogue(string text)
    {
        DialogueText.WriteText(text);
    }

    public void NextText()
    {
        if(queuedTexts.Count == 0)
        {
            DialogueBox.SetActive(false);
            return;
        }
        WriteDialogue(queuedTexts[0]);
        queuedTexts.RemoveAt(0);
    }
}
