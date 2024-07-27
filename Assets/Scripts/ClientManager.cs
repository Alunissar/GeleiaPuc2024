using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClientManager : Singleton<ClientManager>
{
    public CharacterSO[] allCharacters;
    
    private List<CharacterSO> characterQueue = new List<CharacterSO>();

    private CharacterSO activeCharacter;

    public Transform characterSpawnPoint;

    public ScreenSwap deliveryScreen;

    //Creates new queue of characters
    public void PopulateQueue(int characterCount)
    {
        //creates list of characters outside queue
        List<CharacterSO> unQueuedChars = new List<CharacterSO>();
        foreach(CharacterSO character in allCharacters){ unQueuedChars.Add(character); }
        if(unQueuedChars.Count < characterCount) { Debug.LogError("Tried populating character list with too many characters."); }

        //adds a random unqueued character to the queue and removes from unqueued list
        for(int i = 0; i < characterCount; i++)
        {
            int random = UnityEngine.Random.Range(0,unQueuedChars.Count);
            characterQueue.Add(unQueuedChars[random]);
            unQueuedChars.RemoveAt(random);
        }

        //renders character and removes from character queue
        RenderCharacter(characterQueue[0]);
        characterQueue.RemoveAt(0);
    }

    //removes previous char graphics and instantiates new ones
    private void RenderCharacter(CharacterSO character)
    {
        activeCharacter = character;
        
        try{Destroy(characterSpawnPoint.GetChild(0));}
        catch{}
        Instantiate(activeCharacter.clientPrefab, characterSpawnPoint);
        DialogueManager.Instance.WriteName(character);
        character.IntroDialogue();
    }

    //Renders next character in queue and clears graphics if there is none left
    public void NextCharacter()
    {
        //clear graphics
        if(characterQueue.Count == 0) 
        { 
            Destroy(characterSpawnPoint.GetChild(0).gameObject);
            deliveryScreen.SwapScreen(2);

            //Passing a day
            GameManager.Instance.StartDay();

            return;
        }

        //render char
        RenderCharacter(characterQueue[0]);
        characterQueue.RemoveAt(0);
    }

    //Triggers dialogue to active character according to taste
    public void DeliveryDialogue(int taste)
    {
        if(taste > 0)
        {
            DialogueManager.Instance.WriteDialogue(activeCharacter.GetDialoguePrompt(DialogueSO.DialoguePrompt.POSITIVE_FEEDBACK));
        }else 
        if(taste < 0)
        {
            DialogueManager.Instance.WriteDialogue(activeCharacter.GetDialoguePrompt(DialogueSO.DialoguePrompt.NEGATIVE_FEEDBACK));
        }else
        {
            DialogueManager.Instance.WriteDialogue(activeCharacter.GetDialoguePrompt(DialogueSO.DialoguePrompt.NEUTRAL_FEEDBACK));
        }
    }

    //Triggers extra dialogue to active character
    public void ExtraDialogue()
    {
        activeCharacter.ExtraDialogue();
    }
}
