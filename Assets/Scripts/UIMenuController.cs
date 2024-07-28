using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioClip buttonSound;

    public void ChangeToConfig()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        animator.SetTrigger("Config");
    }

    public void StartGame()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        SceneManager.LoadScene(1);
    }

    public void ChangeToCredits()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        animator.SetTrigger("Credits");
    }

    public void ChangeToMenu()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        animator.SetTrigger("Menu");
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        Application.Quit();
        Debug.Log("Quit");
    }
}
