using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : Singleton<ClientManager>
{
    public CharacterSO[] allCharacters;
    
    private List<CharacterSO> characterQueue;

    private CharacterSO activeCharacter;

    public Transform characterSpawnPoint;

    public void PopulateQueue(int characterCount)
    {
        List<CharacterSO> unQueuedChars = new List<CharacterSO>();
        foreach(CharacterSO character in allCharacters){ unQueuedChars.Add(character); }
        if(unQueuedChars.Count < characterCount) { Debug.LogError("Tried populating character list with too many characters."); }

        for(int i = 0; i < characterCount; i++)
        {
            int random = UnityEngine.Random.Range(0,unQueuedChars.Count);
            characterQueue.Add(unQueuedChars[random]);
            unQueuedChars.RemoveAt(random);
        }
        

    }

    private void RenderCharacter(CharacterSO character)
    {
        activeCharacter = character;
        
        if(characterSpawnPoint.GetChild(0) == null)
        {
            Instantiate(activeCharacter, characterSpawnPoint);
        }
    }
}
