using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoMenu : MonoBehaviour
{
    public GameObject toogleFill;

    public void setFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen)
            toogleFill.SetActive(true);
        else
            toogleFill.SetActive(false);


    }

    public void Start()
    {
        if (Screen.fullScreen)
            toogleFill.SetActive(true);
        else
            toogleFill.SetActive(false);
    }
}
