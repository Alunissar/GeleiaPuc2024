using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Character")]
public class CharacterSO : ScriptableObject
{
    public string charName;
    public GameObject graphicsPrefab;
    public DialogueSO[] dialogues;

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
}
