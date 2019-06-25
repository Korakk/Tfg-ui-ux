using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Default : MonoBehaviour
{
    public Slider Volume;
    public void DefaultConfig()
    {
        Volume.value = 100;
        Screen.fullScreen = false;
        Screen.SetResolution(1024, 768, Screen.fullScreen);
        QualitySettings.SetQualityLevel(2);
    }
}
