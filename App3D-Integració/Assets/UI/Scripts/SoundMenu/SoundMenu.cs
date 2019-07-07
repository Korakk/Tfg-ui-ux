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
            PlayerPrefs.SetInt("soundIcon", 3);

        }
        else if(volume > -40 && volume < 0) { //near-max vol.

            minVolume.SetActive(false);
            nearMinVolume.SetActive(false);
            nearMaxVolume.SetActive(true);
            maxVolume.SetActive(false);
            PlayerPrefs.SetInt("soundIcon", 2);

        }
        else if(volume == 0) //max vol.
        {
            minVolume.SetActive(false);
            nearMinVolume.SetActive(false);
            nearMaxVolume.SetActive(false);
            maxVolume.SetActive(true);
            PlayerPrefs.SetInt("soundIcon", 1);


        }
        else if(volume == -80){//min vol.

            minVolume.SetActive(true);
            nearMinVolume.SetActive(false);
            nearMaxVolume.SetActive(false);
            maxVolume.SetActive(false);
            PlayerPrefs.SetInt("soundIcon", 0);

        }
        this.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
        volController();
    }

    public void MuteVolume()
    {
        audioMixer.SetFloat("volume", -80);
        PlayerPrefs.SetInt("Mute", 1);

    }

    public void UnMuteVolume()
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetInt("Mute", 0);

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

    public void soundUiUpdate()
    {
        if(PlayerPrefs.GetInt("Mute") == 0)
        {
            unmute.SetActive(true);
            mute.SetActive(false);
            UnMuteVolume();
        } else
        {
            unmute.SetActive(false);
            mute.SetActive(true);
            MuteVolume();
        }
        SetVolume(PlayerPrefs.GetFloat("volume"));
    }
}
