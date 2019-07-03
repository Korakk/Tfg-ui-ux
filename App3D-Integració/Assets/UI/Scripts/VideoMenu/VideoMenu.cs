using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoMenu : MonoBehaviour
{
    public void setFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
