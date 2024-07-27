using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void ChangeToConfig()
    {
        animator.SetTrigger("Config");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeToCredits()
    {
        animator.SetTrigger("Credits");
    }

    public void ChangeToMenu()
    {
        animator.SetTrigger("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
