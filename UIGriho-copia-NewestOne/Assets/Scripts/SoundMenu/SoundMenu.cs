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
    public GameObject mute, unmute;
    private float volume;
   
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        if(volume > -80 && volume <= -40)//near-min vol.
        {
            minVolume.SetActive(false);
            nearMinVolume.SetActive(true);
            nearMaxVolume.SetActive(false);
            maxVolume.SetActive(false);
        }
        else if(volume > -40 && volume < 0) { //near-max vol.

            minVolume.SetActive(false);
            nearMinVolume.SetActive(false);
            nearMaxVolume.SetActive(true);
            maxVolume.SetActive(false);

        } else if(volume == 0) //max vol.
        {
            minVolume.SetActive(false);
            nearMinVolume.SetActive(false);
            nearMaxVolume.SetActive(false);
            maxVolume.SetActive(true);

        } else if(volume == -80){//min vol.

            minVolume.SetActive(true);
            nearMinVolume.SetActive(false);
            nearMaxVolume.SetActive(false);
            maxVolume.SetActive(false);

        }
        this.volume = volume;
        volController();
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
        volume = (volume >= -64) ? volume - 16 : volume = -80;

        slider.value = volume;
        SetVolume(volume);
        volController();

    }

    public void plusVol()
    {
        volume = (volume <= -16) ? volume + 16 : volume = 0;

        slider.value = volume;
        SetVolume(volume);
        volController();

    }
    
    public void volController()
    {
        if (mute.activeSelf)
        {
            unmute.SetActive(true);
            mute.SetActive(false);
        }
    }
}
