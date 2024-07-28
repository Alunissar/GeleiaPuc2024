using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    public DialogueText dialogueText;
    public DialogueText nameText;
    public GameObject dialogueBox;
    private List<string> queuedTexts = new List<string>();
    private DialogueSO currentDialogue;

    public void WriteDialogue(DialogueSO dialogue)
    {
        queuedTexts.Clear();
        Debug.Log("active true");
        dialogueBox.SetActive(true);
        for(int i = 0; i < dialogue.texts.Length; i++)
        {
            queuedTexts.Add(dialogue.texts[i]);
        }
        //NextText();
        currentDialogue = dialogue;
        WriteDialogue(queuedTexts[0]);
        queuedTexts.RemoveAt(0);
    }

    public void WriteDialogue(string text)
    {
        Debug.Log("speaking: " +text);
        dialogueText.WriteText(text);
    }

    public void WriteName(CharacterSO character)
    {
        nameText.WriteText(character.charName);
    }


    public void NextText()
    {
        //se o texto acabou
        if(queuedTexts.Count == 0)
        {
            //se e um dos que passa de personagem
            if(currentDialogue.prompt == DialogueSO.DialoguePrompt.NEGATIVE_FEEDBACK ||
                    currentDialogue.prompt == DialogueSO.DialoguePrompt.FIRST_MEETING ||
                    currentDialogue.prompt == DialogueSO.DialoguePrompt.SECOND_MEETING ||
                    currentDialogue.prompt == DialogueSO.DialoguePrompt.THIRD_MEETING)
            {
                //fecha o dialogo e passa de personagem
                currentDialogue = null;
                
                dialogueBox.SetActive(false);
                ClientManager.Instance.NextCharacter();
            }else
            //se e um dos que da texto extra 
            if(currentDialogue.prompt == DialogueSO.DialoguePrompt.POSITIVE_FEEDBACK ||
                    currentDialogue.prompt == DialogueSO.DialoguePrompt.NEUTRAL_FEEDBACK)
            {
                ClientManager.Instance.ExtraDialogue();
            }else
            {
                dialogueBox.SetActive(false);
            }
            return;
        }

        WriteDialogue(queuedTexts[0]);
        queuedTexts.RemoveAt(0);
    }
}
