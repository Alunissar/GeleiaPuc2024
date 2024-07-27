using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    public static SoundManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public float GetSFXVolume()
    {
        return sfx.volume;
    }
    public float GetBGMVolume()
    {
        return bgm.volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        sfx.volume = volume;
        Debug.Log(sfx.volume);
    }
    public void ChangeBGMVolume(float volume)
    {
        bgm.volume = volume;
        Debug.Log(bgm.volume);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

    public void PlayBGM(AudioClip clip)
    {
        bgm.clip = clip;
        bgm.Play();
        bgm.loop = true;
    }
}
