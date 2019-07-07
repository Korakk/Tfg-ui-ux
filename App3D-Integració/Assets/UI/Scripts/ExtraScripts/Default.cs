using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Default : MonoBehaviour
{
    public GameObject mainblock;
    public GameObject[] resCheck = new GameObject[4];
    public Slider Volume;
    public void DefaultConfig()
    {
        Volume.value = 100;
        Screen.fullScreen = false;
        Screen.SetResolution(1024, 768, Screen.fullScreen);
        QualitySettings.SetQualityLevel(2);
        LangSetter ls = new LangSetter();
        ls.transformEnglish = mainblock.transform;
        ls.TranslateText("ENG");

        //Resolution Axes
        resCheck[0].SetActive(true);
        resCheck[1].SetActive(false);
        resCheck[2].SetActive(false);
        resCheck[3].SetActive(false);
    }
}
