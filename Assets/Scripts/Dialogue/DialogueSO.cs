using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public enum DialoguePrompt
    {
        FIRST_MEETING,
        SECOND_MEETING,
        LIKES_FOOD,
        DISLIKES_FOOD
    }
    public DialoguePrompt prompt;
    public string[] texts;
}
