using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : MonoBehaviour
{
    public void DefaultConfig()
    {
        Screen.fullScreen = true;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreen);
        QualitySettings.SetQualityLevel(2);
    }
}
