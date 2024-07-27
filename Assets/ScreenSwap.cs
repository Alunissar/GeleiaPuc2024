using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwap : MonoBehaviour
{
    //screen type (bc buttons don't pass enums)
    //0 = deliver
    //1 = kitchen
    //2 = shop
    public int type;
    public GameObject UICanvas;
    public void SwapScreen(int i)
    {
        ScreenSwap[] screenObjects = FindObjectsByType<ScreenSwap>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach(ScreenSwap screenObject in screenObjects)
        {
            if(screenObject.type == type)
            {
                transform.position = Vector3.right * 50;
                UICanvas.SetActive(false);
                screenObject.transform.position = Vector3.zero;
                screenObject.UICanvas.SetActive(true);
                return;
            }
        }
        Debug.LogWarning($"No screen with type {type} found in scene, cannot swap.");
    }
}
