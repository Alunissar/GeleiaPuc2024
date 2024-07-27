using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudioSlider : MonoBehaviour
{
    [SerializeField] Scrollbar slider;
    [SerializeField] bool isSFX;

    private void Update()
    {
        if (isSFX)
            slider.value = SoundManager.instance.GetSFXVolume();
        else
            slider.value = SoundManager.instance.GetBGMVolume();
    }
    public void BGMChange(float value)
    {
        SoundManager.instance.ChangeBGMVolume(value);
    }

    public void SFXChange(float value)
    {
        SoundManager.instance.ChangeSFXVolume(value);
    }

}
