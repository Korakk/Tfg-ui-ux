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

    private string[] ESPMainText = new string[] { "Jugar", "Opciones", "Salir" };
    private string[] ESPPauseText = new string[] { "Salir", "Resumen", "Opciones", "Menú Principal" };
    private string[] ESPSettingsText = new string[] { "Sonido", "Video", "Idioma", "Volver" };
    private string[] ESPSoundText = new string[] { "Volver", "Silenciar", "Silenciar", "Volumen" };
    private string[] ESPVideoText = new string[] { "Volver", "Pantalla Completa", "Calidad gràfica", "Resolución", "Por defecto", "Reiniciar" };
    private string[] ESPVideoTextGraphics = new string[] { "Alta", "Media", "Baja" };
    private string[] ESPLanguageText = new string[] { "Volver", "Inglés", "Catalan", "Español" };
    private string[] ESPAreYouSure = new string[] { "Quieres volver al menú principal?", "Salir del juego?", "Estás seguro que quieres volver a la configuración por defecto?", "Estás seguro que quieres volver a empezar?" };
    private string[] ESP_CATAreYouSureBtn = new string[] { "Sí", "No" };
    //private string[] CATAreYouSure = new string[] { "Vols tornar al menú principal?", "Sortir del joc?", "Estàs segur que vols tornar a la configuració per defecte", "Estàs segur que vols tornar a començar?" };
    //private string[] ENGAreYouSure = new string[] { "Back to Main Menu?", "Exit the game?", "Are you sure you want to set DEFAULT configuration?", "Are you sure you want to RESTART the game?" };
    //private string[] ENGAreYouSureBtn = new string[] { "Yes", "No" };
    

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
        for (int i = 0; i < menu.GetChild(0).GetChildCount(); i++)
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
                    SetTextMeshProText(langChooser.getSoundText()[count], menu.GetChild(counter).GetChild(i));
                    count++;
                }
            }

            else if (ContainsText("Volume", menu.GetChild(counter)))
            {

                if (ContainsText("Text", menu.GetChild(counter).GetChild(i)))
                {
                    SetTextMeshProText(langChooser.getSoundText()[3], menu.GetChild(counter).GetChild(i));
                }
            }
            
            
        }
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
                    SetTextMeshProText(langChooser.getMainVideoText()[counter-1], menu.GetChild(counter).GetChild(i));
            }
            else if (ContainsText("Toogle", menu.GetChild(counter)))
            {
                if (ContainsText("Label", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(ESPVideoText[counter - 1], menu.GetChild(counter).GetChild(i));

            } else if (ContainsText("Graphics Radios", menu.GetChild(counter))) {
                if (ContainsText("Title", menu.GetChild(counter).GetChild(i)))
                    SetTextMeshProText(langChooser.getMainVideoText()[counter - 1], menu.GetChild(counter).GetChild(i));

                else if (ContainsText("Background Image", menu.GetChild(counter).GetChild(i)))
                {
                    int j;
                    for(j=0; j < menu.GetChild(counter).GetChild(i).childCount; j++)
                    {
                        if (ContainsText("Text", menu.GetChild(counter).GetChild(i).GetChild(j)))
                        {
                            SetTextMeshProText(langChooser.getVGraphicsText()[index], menu.GetChild(counter).GetChild(i).GetChild(j));
                            index += 1;
                        }

                    }
                }

            } else if(ContainsText("Resolution", menu.GetChild(counter))){
                SetTextMeshProText(langChooser.getMainVideoText()[counter - 1], menu.GetChild(counter));
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
