using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject mainblock;
    public GameObject EngIcon, EspIcon, CatIcon, EngCheck, EspCheck, CatCheck;
    public GameObject mute, unmute, slider;
    public GameObject r1024, r1366, r1920, rCustom, Fs;
    public GameObject highQ, medQ, lowQ;
    // Start is called before the first frame update
    void Start()
    {
        LangSetter ls = new LangSetter();
        ls.transformEnglish = mainblock.transform;
        ls.TranslateText(PlayerPrefs.GetString("Lang"));
    }

    public void MainSettings()
    {
        if (PlayerPrefs.GetString("Lang") == "ENG")
        {
            EngIcon.SetActive(true);
            EspIcon.SetActive(false);
            CatIcon.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Lang") == "ESP")
        {
            EngIcon.SetActive(false);
            EspIcon.SetActive(true);
            CatIcon.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Lang") == "CAT")
        {
            EngIcon.SetActive(false);
            EspIcon.SetActive(false);
            CatIcon.SetActive(true);
        }
    }
    public void langSettings()
    { 
        if(PlayerPrefs.GetString("Lang") == "ENG")
        {
            EngCheck.SetActive(true);
            EspCheck.SetActive(false);
            CatCheck.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Lang") == "ESP")
        {
            EngCheck.SetActive(false);
            EspCheck.SetActive(true);
            CatCheck.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Lang") == "CAT")
        {
            EngCheck.SetActive(false);
            EspCheck.SetActive(false);
            CatCheck.SetActive(true);
        }

    }

    public void soundSettings()
    {
        SoundMenu sm = new SoundMenu();
        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            if(unmute.activeInHierarchy != true)
                sm.UnMuteVolume();
        
            unmute.SetActive(true);
            mute.SetActive(false);
            
        }
        else
        {
            unmute.SetActive(false);
            mute.SetActive(true);
            sm.MuteVolume();
        }
        slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("volume");
    }

    public void screenSettings()
    {
        ResolutionHandler rh = new ResolutionHandler();
        Screen.fullScreen = PlayerPrefs.GetInt("Fs") == 0 ? false : true;
        if (PlayerPrefs.GetInt("Fs") == 0)
        {
            Fs.GetComponent<Toggle>().isOn = false;
        } else
        {
            Fs.GetComponent<Toggle>().isOn = true;
        }

        if (PlayerPrefs.GetString("Resolution") == "1024")
        {
            Screen.SetResolution(1024, 768, PlayerPrefs.GetInt("Fs") == 0 ? false : true);

            r1024.SetActive(true);
            r1366.SetActive(false);
            r1920.SetActive(false);
            rCustom.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Resolution") == "1366")
        {
            Screen.SetResolution(1366, 768, PlayerPrefs.GetInt("Fs") == 0 ? false : true);

            r1024.SetActive(false);
            r1366.SetActive(true);
            r1920.SetActive(false);
            rCustom.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Resolution") == "1920")
        {
            Screen.SetResolution(1920, 1080, PlayerPrefs.GetInt("Fs") == 0 ? false : true);

            r1024.SetActive(false);
            r1366.SetActive(false);
            r1920.SetActive(true);
            rCustom.SetActive(false);
        }
        else
        {
            rh.setCustomResolution();

            r1024.SetActive(false);
            r1366.SetActive(false);
            r1920.SetActive(false);
            rCustom.SetActive(true);
        }

    }

    public void graphicQSettings()
    {
        graphicsQuality gq = new graphicsQuality();
        if(PlayerPrefs.GetInt("Quality") == 2)
        {
            QualitySettings.SetQualityLevel(2);
            highQ.SetActive(true);
            medQ.SetActive(false);
            lowQ.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Quality") == 1)
        {
            QualitySettings.SetQualityLevel(1);
            highQ.SetActive(false);
            medQ.SetActive(true);
            lowQ.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Quality") == 0)
        {
            QualitySettings.SetQualityLevel(0);
            highQ.SetActive(false);
            medQ.SetActive(false);
            lowQ.SetActive(true);
        }

    }
}
