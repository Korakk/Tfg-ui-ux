using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangChooser : MonoBehaviour
{
    public bool spanishActive = false;
    public bool catalanActive = false;
    public bool englishActive = true;

    private string[] titles, mainText, pauseText, settingsText, soundText, videoText, videoTextGraphics, languageText, areYouSure, areYouSureBtn;

    public void setValues()
    {
        if (englishActive)
        {
            titles = new string[] { "Pause", "Settings", "Sound", "Video", "Language" };
            mainText = new string[] { "Play", "Settings", "Exit" };
            pauseText = new string[] { "Exit the game", "Resume", "Settings", "Main Menu" };
            settingsText = new string[] { "Sound", "Video", "Language", "Back" };
            soundText = new string[] { "Back", "Mute", "Mute", "Volume" };
            videoText = new string[] { "Back", "Fullscreen", "Graphics Quality", "Resolution", "Default", "Reset" };
            videoTextGraphics = new string[] { "High", "Medium", "Low" };
            languageText = new string[] { "Back", "English", "Catalan", "Spanish" };
            areYouSure = new string[] { "Back to Main Menu?", "Exit the game?", "Are you sure you want to set DEFAULT configuration?", "Are you sure you want to RESTART the game?" };
            areYouSureBtn = new string[] { "Yes", "No" };
        }

        else if (catalanActive)
        {
            titles = new string[] { "Pausa", "Opcions", "So", "Video", "Idioma" };
            mainText = new string[] { "Jugar", "Opcions", "Sortir" };
            pauseText = new string[] {"Resumir", "Opcions", "Menú Principal", "Sortir" };
            settingsText = new string[] { "So", "Video", "Idioma", "Tornar" };
            soundText = new string[] { "Tornar", "Silenciar", "Silenciar", "Volum" };
            videoText = new string[] { "Tornar", "Pantalla Complerta", "Qualitat gràfica", "Resolució", "Per defecte", "Reiniciar" };
            videoTextGraphics = new string[] { "Alta", "Mitja", "Baixa" };
            languageText = new string[] { "Tornar", "Anglès", "Català", "Espanyol" };
            areYouSure = new string[] { "Vols tornar al menú principal?", "Sortir del joc?", "Estàs segur que vols tornar a la configuració per defecte?", "Estàs segur que vols tornar a començar?" };
            areYouSureBtn = new string[] { "Sí", "No" };
        }

        else if (spanishActive)
        {
            titles = new string[] { "Pausa", "Opciones", "Sonido", "Video", "Idioma" };
            mainText = new string[] { "Jugar", "Opciones", "Salir" };
            pauseText = new string[] { "Resumen", "Opciones", "Menú Principal", "Salir" };
            settingsText = new string[] { "Sonido", "Video", "Idioma", "Volver" };
            soundText = new string[] { "Volver", "Silenciar", "Silenciar", "Volumen"};
            videoText = new string[] { "Volver", "Pantalla Completa", "Calidad gràfica", "Resolución", "Por defecto", "Reiniciar" };
            videoTextGraphics = new string[] { "Alta", "Media", "Baja" };
            languageText = new string[] { "Volver", "Inglés", "Catalán", "Español" };
            areYouSure = new string[] { "Quieres volver al menú principal?", "Salir del juego?", "Estás seguro que quieres volver a la configuración por defecto?", "Estás seguro que quieres volver a empezar?" };
            areYouSureBtn = new string[] { "Sí", "No" };
        }
    }

    public string[] getTitles()
    {
        return titles;
    }

    public string[] getMainText()
    {
        return mainText;
    }

    public string[] getPauseText()
    {
        return pauseText;
    }

    public string[] getSettingsText()
    {
        return settingsText;
    }

    public string[] getSoundText()
    {
        return soundText;
    }

    public string[] getMainVideoText()
    {
        return videoText;
    }

    public string[] getVGraphicsText()
    {
        return videoTextGraphics;
    }

    public string[] getLanguageText()
    {
        return languageText;
    }

    public string[] getAreYouSure()
    {
        return areYouSure;
    }
    public string[] getAreYouSureBtn()
    {
        return areYouSureBtn;
    }

    public void setESP()
    {
        spanishActive = true;
        englishActive = false;
        catalanActive = false;
 
    }

    public void setENG()
    {
        spanishActive = false;
        englishActive = true;
        catalanActive = false;

    }

    public void setCAT()
    {
        spanishActive = false;
        englishActive = false;
        catalanActive = true;

    }
}

