 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public Transform transformEnglish;
    public GameObject grandChild;
    public bool SpanishActive = false;
    public bool CatalanActive = false;
    public bool EnglishActive = true;

    private string[] ESPMainText = new string[] { "Jugar", "Opciones", "Salir" };
    private string[] ESPPauseText = new string[] { "Salir", "Resumen", "Opciones", "Menú Principal" };
    private string[] ESPSettingsText = new string[] { "Sonido", "Video", "Idioma", "Volver" };
    private string[] ESPSoundText = new string[] { "Volver", "Silenciar", "Silenciar", "Volumen" };
    private string[] ESPVideoText = new string[] { "Volver", "Pantalla Completa", "Calidad gràfica", "Resolución" };
    private string[] ESPVideoTextGraphics = new string[] { "Alta", "Media", "Baja" };
    private string[] ESPLanguageText = new string[] { "Volver", "Inglés", "Catalan", "Español" };

    public void translateText()
    {
        transformEnglish = gameObject.transform.GetChild(0);
        grandChild = gameObject.transform.gameObject;
        int count = gameObject.transform.GetChildCount();
        int i;
        for (i = 0; i < count; i++)
        {
            ObtainMenuText(gameObject.transform.GetChild(i));
        }
    }

    private void ObtainMenuText(Transform menu)
    {
        SetAllMenusText(menu);
        SetAreYouSurePopup(menu);
    }

    private void SetAreYouSurePopup(Transform menu, int counter = 0)
    {
        if (menu.name.Contains("AreYouSure"))
        {
            for (counter = 0; counter < menu.GetChildCount(); counter++)
            {
                Debug.Log(menu.GetChild(counter));
            }
        }

    }

    private void SetAllMenusText(Transform menu)
    {
        int counter;
        for (counter = 0; counter < menu.GetChildCount(); counter++)
        {
            if(menu.name == "MainMenu" || menu.name == "PauseMenu")
                SetMainAndPauseMenuText(menu, counter);

            if(menu.name == "SoundMenu")
                SetSoundMenuText(menu, counter);

            if (menu.name == "VideoMenu")
                SetVideoMenuText(menu, counter);

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
            SetTextMeshProText("Pausa", menu.GetChild(counter).GetChild(0));
        }
        if (ContainsText("Button", menu.GetChild(counter)))
        {
            for (i = 0; i < menu.GetChild(counter).GetChildCount(); i++)
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                {
                    if (menu.name == "MainMenu")
                        SetTextMeshProText(ESPMainText[counter - 1], menu.GetChild(counter).GetChild(i));

                    if (menu.name == "PauseMenu")
                        SetTextMeshProText(ESPPauseText[counter - 1], menu.GetChild(counter).GetChild(i));
                }
            }
        }
    }


    private void SetSoundMenuText(Transform menu, int counter)
    {
        int i;
        if(ContainsText("Title", menu.GetChild(counter)))
            SetTextMeshProText("Sonido", menu.GetChild(counter).GetChild(0));

        for (i = 0; i < menu.GetChild(counter).GetChildCount(); i++)
        {
            if (ContainsText("Button", menu.GetChild(counter)))
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(ESPSoundText[counter - 1], menu.GetChild(counter).GetChild(i));
            }

            else if (ContainsText("Volume", menu.GetChild(counter)))
            {

                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                {
                    SetTextMeshProText("Volumen", menu.GetChild(counter).GetChild(i));
                }

            }
        }
    }

    private void SetVideoMenuText(Transform menu, int counter)
    {
        int i, index = 0;
        if (ContainsText("Title", menu.GetChild(counter)))
            SetTextMeshProText("Vídeo", menu.GetChild(counter).GetChild(0));//Canviar el nom per screen i pantalla.
        for (i = 0; i < menu.GetChild(counter).GetChildCount(); i++)
        {
            if (ContainsText("Button", menu.GetChild(counter)))
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(ESPVideoText[counter - 1], menu.GetChild(counter).GetChild(i));
            }
            else if (ContainsText("Toogle", menu.GetChild(counter)))
            {
                if (ContainsText("Label", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(ESPVideoText[counter - 1], menu.GetChild(counter).GetChild(i));

            } else if (ContainsText("Graphics Radios", menu.GetChild(counter))) {
                if (ContainsText("Title", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(ESPVideoText[counter - 1], menu.GetChild(counter).GetChild(i));

                else if(ContainsText("Background Image", menu.GetChild(counter).GetChild(i)))
                {
                    int j;
                    for(j=0; j < menu.GetChild(counter).GetChild(i).GetChildCount(); j++)
                    {
                        if (ContainsText("Text", menu.GetChild(counter).GetChild(i).GetChild(j)))
                        {
                            SetTextMeshProText(ESPVideoTextGraphics[index], menu.GetChild(counter).GetChild(i).GetChild(j));
                            index += 1;
                        }

                    }
                }

            } else if(ContainsText("Resolution", menu.GetChild(counter))){
                SetTextMeshProText(ESPVideoText[counter-1], menu.GetChild(counter));
            }
        }
    }

    private void SetLanguageMenuText(Transform menu, int counter)
    {
        int i;
        if (ContainsText("Title", menu.GetChild(counter)))
            SetTextMeshProText("Idioma", menu.GetChild(counter).GetChild(0));

        for (i = 0; i < menu.GetChild(counter).GetChildCount(); i++)
        {
            if (ContainsText("Button", menu.GetChild(counter)))
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(ESPLanguageText[counter - 1], menu.GetChild(counter).GetChild(i));
            } 
            else if(ContainsText("Lang", menu.GetChild(counter)))
            {
                int j;
                
                for (j = 0; j < menu.GetChild(counter).GetChild(i).GetChildCount(); j++)
                {
                    if (ContainsText("Text", menu.GetChild(counter).GetChild(i).GetChild(j)))
                        SetTextMeshProText(ESPLanguageText[counter - 1], menu.GetChild(counter).GetChild(i).GetChild(j));
                }
                   
            }
        }
    }

    private void SetSettingsMenuText(Transform menu, int counter)
    {
        int i;
        if (ContainsText("Title", menu.GetChild(counter)))
            SetTextMeshProText("Opciones", menu.GetChild(counter).GetChild(0));

        for (i = 0; i < menu.GetChild(counter).GetChildCount(); i++)
        {
            if (ContainsText("Button", menu.GetChild(counter)))
            {
                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(ESPSettingsText[counter - 1], menu.GetChild(counter).GetChild(i));
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
