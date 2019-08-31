using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppDebug : MonoBehaviour
{

    public void Debugging()
    {
        Debug.Log(PlayerPrefs.GetString("Lang"));
        Debug.Log(PlayerPrefs.GetInt("Mute"));
        Debug.Log(PlayerPrefs.GetInt("soundIcon"));
        Debug.Log(PlayerPrefs.GetFloat("volume"));
        Debug.Log(PlayerPrefs.GetInt("Quality"));
        Debug.Log(PlayerPrefs.GetString("Resolution"));
        Debug.Log(PlayerPrefs.GetInt("Fs"));
    }
}
