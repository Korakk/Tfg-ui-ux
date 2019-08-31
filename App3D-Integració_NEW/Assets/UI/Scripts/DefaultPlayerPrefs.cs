using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPlayerPrefs : MonoBehaviour
{

    private void Awake()
    {
        PlayerPrefs.SetString("Lang", "ENG");//English
        PlayerPrefs.SetInt("Mute", 0);//Not muted
        PlayerPrefs.SetInt("soundIcon", 1);//Max volume icon
        PlayerPrefs.SetFloat("volume", 0);//max volume
        PlayerPrefs.SetInt("Quality", 2);//High quality
        PlayerPrefs.SetString("Resolution", "1024"); //Default resolution width
        PlayerPrefs.SetInt("Fs", 0);//Fullscreen
    }
}
