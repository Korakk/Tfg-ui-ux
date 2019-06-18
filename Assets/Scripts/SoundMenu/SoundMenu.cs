using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject maxVolume, nearMaxVolume, nearMinVolume, minVolume;
    public Slider slider;
    private float volume;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        if(volume > -80 && volume <= -40)//near-min vol.
        {
            nearMaxVolume.SetActive(false);
            nearMinVolume.SetActive(true);
            minVolume.SetActive(false);
        }
        else if(volume > -40 && volume < 0) { //near-max vol.

            nearMaxVolume.SetActive(true);
            nearMinVolume.SetActive(false);
            maxVolume.SetActive(false);

        } else if(volume == 0) //max vol.
        {
            nearMaxVolume.SetActive(false);
            maxVolume.SetActive(true);

        } else if(volume == -80){//min vol.

            nearMinVolume.SetActive(false);
            minVolume.SetActive(true);

        }
        this.volume = volume;
    }

    public void MuteVolume()
    {
        audioMixer.SetFloat("volume", -80);
    }

    public void UnMuteVolume()
    {
        audioMixer.SetFloat("volume", volume);

    }

    //Provoquem 5 steps de volumen
    public void minusVol()
    {
        if(volume >= -64)
        {
            volume -= 16;
            SetVolume(volume);
            slider.value = volume;
        }
    }

    public void plusVol()
    {
        if (volume <= -16)
        {
            volume += 16;
            SetVolume(volume);
            slider.value = volume;
        }

    }
}
