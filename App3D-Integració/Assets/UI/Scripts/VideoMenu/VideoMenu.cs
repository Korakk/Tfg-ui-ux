using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoMenu : MonoBehaviour
{
    public GameObject FsCheck;

    public void setFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen)
            PlayerPrefs.SetInt("Fs", 1);
        else
            PlayerPrefs.SetInt("Fs", 0);
    }
}
