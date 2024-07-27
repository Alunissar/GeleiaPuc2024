using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public enum DialoguePrompt
    {
        FIRST_INTRO,
        NORMAL_INTRO,
        POSITIVE_FEEDBACK,
        NEUTRAL_FEEDBACK,
        NEGATIVE_FEEDBACK,
        FIRST_MEETING,
        SECOND_MEETING,
        THIRD_MEETING
    }
    public DialoguePrompt prompt;
    public string[] texts;
}
