using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueText : MonoBehaviour
{
    public TMP_Text textBox;
    void Awake()
    {
        textBox = GetComponent<TMP_Text>();
    }

    public void WriteText(string text)
    {
        textBox.text = text;
        StartCoroutine(ResizeFix());
    }

    private IEnumerator ResizeFix()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        textBox.text = textBox.text + " ";
    }
}
