using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionHandler : MonoBehaviour
{
    public int resWidth, resHeight;
    private int customWidth, customHeight;

    public void Start()
    {
        customWidth = Screen.width;
        customHeight = Screen.height;
        //Set default resolution (1024x768)
        Screen.SetResolution(1024, 768, Screen.fullScreen=false); //3rd parameter makes it a window instead of fullscreen.
    }

    public void SetResolution()
    {
        Screen.SetResolution(resWidth, resHeight, Screen.fullScreen);
    }

    public void setCustomResolution()
    {
        Screen.SetResolution(customWidth, customHeight, Screen.fullScreen);
    }
}
