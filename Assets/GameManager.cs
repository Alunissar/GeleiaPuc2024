using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int dayCount;
    public void StartGame()
    {
        dayCount = 0;
    }
    public void StartDay()
    {
        dayCount++;
        ClientManager.Instance.PopulateQueue(5);
    }
}
