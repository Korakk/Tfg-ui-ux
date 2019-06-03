using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphicsQuality : MonoBehaviour
{

    public GameObject HighQuality, MediumQuality, LowQuality;
    public int qualityIndex;

    public void HighQualityActive()
    {
        HighQuality.SetActive(true);
        MediumQuality.SetActive(false);
        LowQuality.SetActive(false);
    }

    public void MediumQualityActive()
    {
        HighQuality.SetActive(false);
        MediumQuality.SetActive(true);
        LowQuality.SetActive(false);
    }

    public void LowQualityActive()
    {
        HighQuality.SetActive(false);
        MediumQuality.SetActive(false);
        LowQuality.SetActive(true);
    }

    public void setQuality()
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
