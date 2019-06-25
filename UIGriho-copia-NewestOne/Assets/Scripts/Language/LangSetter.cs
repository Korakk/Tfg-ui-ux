 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LangSetter : MonoBehaviour
{
    public Transform transformEnglish;
    LangChooser langChooser = new LangChooser();
    private int count = 0;
    private int soundIndex = 0;
    

    public void TranslateText(string lang)
    {

        if(lang == "ENG")
        {
            langChooser.setENG();
            langChooser.setValues();
        }

        if (lang == "ESP")
        {
            langChooser.setESP();
            langChooser.setValues();
        }

        if (lang == "CAT")
        {
            langChooser.setCAT();
            langChooser.setValues();
        }
        transformEnglish = gameObject.transform.GetChild(0);
        int count = gameObject.transform.childCount;
        int i;
        for (i = 0; i < count; i++)
        {
            ObtainMenuText(gameObject.transform.GetChild(i));
        }
    }

    private void ObtainMenuText(Transform menu)
    {
        SetAllMenusText(menu);
        SetAreYouSureBlock(menu);
    }

    private void SetAreYouSureBlock(Transform menu, int counter = 0)
    {
        if (menu.name.Contains("AreYouSure"))
        {
            for (counter = 0; counter < menu.childCount; counter++)
            {
                if (menu.GetChild(counter).name.Contains("MainMenu"))
                    SureTextChange(menu.GetChild(counter), counter);

                if (menu.GetChild(counter).name.Contains("Exit"))
                    SureTextChange(menu.GetChild(counter), counter);

                if (menu.GetChild(counter).name.Contains("Restart"))
                    SureTextChange(menu.GetChild(counter), counter);

                if (menu.GetChild(counter).name.Contains("Default"))
                    SureTextChange(menu.GetChild(counter), counter);
            }
        }

    }
    private void SureTextChange(Transform menu, int counter)
    {
        for (int i = 0; i < menu.GetChild(0).childCount; i++)
        {
            if (ContainsText("Message", menu.GetChild(0).GetChild(i)))
                SetTextMeshProText(langChooser.getAreYouSure()[counter], menu.GetChild(0).GetChild(i));

            if(ContainsText("Yes", menu.GetChild(0).GetChild(i)))
                SetText(langChooser.getAreYouSureBtn()[0], menu.GetChild(0).GetChild(i).GetChild(0));

            if (ContainsText("No", menu.GetChild(0).GetChild(i)))
                SetText(langChooser.getAreYouSureBtn()[1], menu.GetChild(0).GetChild(i).GetChild(0));
        }
    }

    private void SetAllMenusText(Transform menu)
    {
        int counter;
        for (counter = 0; counter < menu.childCount; counter++)
        {
            if(menu.name == "MainMenu" || menu.name == "PauseMenu")
                SetMainAndPauseMenuText(menu, counter);

            if(menu.name == "SoundMenu")
                SetSoundMenuText(menu, counter);

            if (menu.name == "VideoMenu")
                SetVideoMenuText(menu, counter);

            if (menu.name == "ScreenMenu")
                SetScreenMenuText(menu, counter);

            if (menu.name == "GraphicsMenu")
                SetGraphicsMenuText(menu, counter);

            if (menu.name == "LanguageMenu")
                SetLanguageMenuText(menu, counter);

            if (menu.name == "SettingsMenu")
                SetSettingsMenuText(menu, counter);

        }
    }

    private void SetMainAndPauseMenuText(Transform menu, int counter)
    {
        int i;
        if (menu.name == "PauseMenu" && ContainsText("Title", menu.GetChild(counter)))
        {
            SetTextMeshProText(langChooser.getTitles()[0], menu.GetChild(counter).GetChild(0));
        }
        if (ContainsText("Button", menu.GetChild(counter)))
        {
            for (i = 0; i < menu.GetChild(counter).childCount; i++)
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                {
                    if (menu.name == "MainMenu")
                        SetTextMeshProText(langChooser.getMainText()[counter-1], menu.GetChild(counter).GetChild(i));

                    if (menu.name == "PauseMenu")
                        SetTextMeshProText(langChooser.getPauseText()[counter - 1], menu.GetChild(counter).GetChild(i));
                }
            }
        }
    }


    private void SetSoundMenuText(Transform menu, int counter)
    {
        int i;
        if (ContainsText("Title", menu.GetChild(counter)))
            SetTextMeshProText(langChooser.getTitles()[2], menu.GetChild(counter).GetChild(0));

        for (i = 0; i < menu.GetChild(counter).childCount; i++)
        {

            if (ContainsText("Button", menu.GetChild(counter)))
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                {
                    Debug.Log(soundIndex);
                    Debug.Log(menu.GetChild(counter).GetChild(i));
                    SetTextMeshProText(langChooser.getSoundText()[soundIndex], menu.GetChild(counter).GetChild(i));
                }
                soundIndex++;

            }

            else if (ContainsText("Volume", menu.GetChild(counter)))
            {

                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                {
                    SetTextMeshProText(langChooser.getSoundText()[3], menu.GetChild(counter).GetChild(i));
                }
            }
            
            
        }
        soundIndex = 0;
    }

    private void SetVideoMenuText(Transform menu, int counter)
    {
        int i, index = 0;
        if (ContainsText("Title", menu.GetChild(counter)))
            SetTextMeshProText(langChooser.getTitles()[3], menu.GetChild(counter).GetChild(0));//Canviar el nom per screen i pantalla.
        for (i = 0; i < menu.GetChild(counter).childCount; i++)
        {
            if (ContainsText("Button", menu.GetChild(counter)))
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(langChooser.getMainVideoOptionsText()[counter-1], menu.GetChild(counter).GetChild(i));
            }
        }
    }

    public void SetScreenMenuText(Transform menu, int counter)
    {
        int i, index = 0;
        if (ContainsText("Title", menu.GetChild(counter)))
            SetTextMeshProText(langChooser.getTitles()[4], menu.GetChild(counter).GetChild(0));

        for (i = 0; i < menu.GetChild(counter).childCount; i++)
        {
            if (ContainsText("Button", menu.GetChild(counter)))
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(langChooser.getVScreenText()[counter - 1], menu.GetChild(counter).GetChild(i));
            }

            else if (ContainsText("Toogle", menu.GetChild(counter)))
            {
                if (ContainsText("Label", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(langChooser.getVScreenText()[counter - 1], menu.GetChild(counter).GetChild(i));
            }

            else if (ContainsText("Resolution", menu.GetChild(counter)))
            {
                SetTextMeshProText(langChooser.getVScreenText()[counter - 1], menu.GetChild(counter));
                SetTextMeshProText(langChooser.getVScreenText()[3], menu.GetChild(counter).GetChild(3));
            }
        }
    }

    public void SetGraphicsMenuText(Transform menu, int counter)
    {
            int i, index = 0;
            if (ContainsText("Title", menu.GetChild(counter)))
                SetTextMeshProText(langChooser.getTitles()[5], menu.GetChild(counter).GetChild(0));

            for (i = 0; i < menu.GetChild(counter).childCount; i++)
            {
                if (ContainsText("Button", menu.GetChild(counter)))
                {
                    if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                        SetTextMeshProText(langChooser.getVGraphicsText()[3], menu.GetChild(counter).GetChild(i));
                }

                else if (ContainsText("Graphics Radios", menu.GetChild(counter)))
                {
                    if (ContainsText("Title", menu.GetChild(counter).GetChild(i)))
                        SetTextMeshProText(langChooser.getVGraphicsText()[counter - 1], menu.GetChild(counter).GetChild(i));

                    else if (ContainsText("Background Image", menu.GetChild(counter).GetChild(i)))
                    {
                        int j;
                        for (j = 0; j < menu.GetChild(counter).GetChild(i).childCount; j++)
                        {
                            if (ContainsText("Text", menu.GetChild(counter).GetChild(i).GetChild(j)))
                            {
                                SetTextMeshProText(langChooser.getVGraphicsText()[index], menu.GetChild(counter).GetChild(i).GetChild(j));
                                index += 1;
                            }

                        }
                    }

                }

            }
    }

    private void SetLanguageMenuText(Transform menu, int counter)
    {
        int i;
        if (ContainsText("Title", menu.GetChild(counter)))
            SetTextMeshProText(langChooser.getTitles()[4], menu.GetChild(counter).GetChild(0));

        for (i = 0; i < menu.GetChild(counter).childCount; i++)
        {
            if (ContainsText("Button", menu.GetChild(counter)))
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(langChooser.getLanguageText()[counter-1], menu.GetChild(counter).GetChild(i));
            } 
            else if(ContainsText("Lang", menu.GetChild(counter)))
            {
                int j;
                
                for (j = 0; j < menu.GetChild(counter).GetChild(i).childCount; j++)
                {
                    if (ContainsText("Text", menu.GetChild(counter).GetChild(i).GetChild(j)))
                        SetTextMeshProText(langChooser.getLanguageText()[counter - 1], menu.GetChild(counter).GetChild(i).GetChild(j));
                }
                   
            }
        }
    }

    private void SetSettingsMenuText(Transform menu, int counter)
    {
        int i;
        if (ContainsText("Title", menu.GetChild(counter)))
            SetTextMeshProText(langChooser.getTitles()[1], menu.GetChild(counter).GetChild(0));

        for (i = 0; i < menu.GetChild(counter).childCount; i++)
        {
            if (ContainsText("Button", menu.GetChild(counter)))
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(langChooser.getSettingsText()[counter - 1], menu.GetChild(counter).GetChild(i));
            }
        }
    }

    private bool ContainsText(string text, Transform menuChild)
    {
        return menuChild.name.Contains(text);
    }
    
    private void SetTextMeshProText(string text, Transform menuChild)
    {
        if(menuChild.gameObject.GetComponent<TextMeshProUGUI>() != null)
            menuChild.gameObject.GetComponent<TextMeshProUGUI>().text = text;
    }

    private void SetText(string text, Transform menuChild)
    {
        if (menuChild.gameObject.GetComponent<Text>() != null)
            menuChild.gameObject.GetComponent<Text>().text = text;
    }

}
