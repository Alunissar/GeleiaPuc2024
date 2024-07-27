using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Character")]
public class CharacterSO : ScriptableObject
{
    public string charName;
    public Client clientPrefab;
    public DialogueSO[] dialogues;
    public bool _hasMet;
    public int meetingTimes;

    private void Start() {
        _hasMet = false;
        meetingTimes = 0;
    }

    //Returns character dialogue from prompt type
    public DialogueSO GetDialoguePrompt(DialogueSO.DialoguePrompt prompt)
    {
        foreach(DialogueSO dialogue in dialogues)
        {
            if(dialogue.prompt == prompt)
            {
                return dialogue;
            }
        }
        Debug.LogWarning($"no dialogue of prompt {prompt} found in {charName}.");
        return null;
    }

    public void IntroDialogue()
    {
        if(!_hasMet)
        {
            DialogueManager.Instance.WriteDialogue(GetDialoguePrompt(DialogueSO.DialoguePrompt.FIRST_INTRO));
            _hasMet = true;
        }else
        {
            DialogueManager.Instance.WriteDialogue(GetDialoguePrompt(DialogueSO.DialoguePrompt.NORMAL_INTRO));
        }
    }

    public void ExtraDialogue()
    {
        switch(meetingTimes)
        {
            case(0):
                DialogueManager.Instance.WriteDialogue(GetDialoguePrompt(DialogueSO.DialoguePrompt.FIRST_MEETING));
            break;

            case(1):
                DialogueManager.Instance.WriteDialogue(GetDialoguePrompt(DialogueSO.DialoguePrompt.SECOND_MEETING));
            break;

            default:
                DialogueManager.Instance.WriteDialogue(GetDialoguePrompt(DialogueSO.DialoguePrompt.THIRD_MEETING));
            break;
        }

        meetingTimes++;
    }
}
