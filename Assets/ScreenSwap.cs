using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwap : MonoBehaviour
{
    public bool _type;  //true and false for different screens
    public GameObject UICanvas;
    public void SwapScreen()
    {
        ScreenSwap[] screenObjects = FindObjectsByType<ScreenSwap>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach(ScreenSwap screenObject in screenObjects)
        {
            if(screenObject._type != _type)
            {
                transform.position = Vector3.right * 50;
                UICanvas.SetActive(false);
                screenObject.transform.position = Vector3.zero;
                screenObject.UICanvas.SetActive(true);
                return;
            }
        }
        Debug.LogWarning($"No screen with different type found in scene, cannot swap.");
    }
}
