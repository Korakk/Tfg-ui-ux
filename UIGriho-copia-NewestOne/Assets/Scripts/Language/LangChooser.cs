using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangChooser : MonoBehaviour
{
    public bool spanishActive = false;
    public bool catalanActive = false;
    public bool englishActive = true;

    private string[] titles, mainText, pauseText, settingsText, soundText, videoOptions, videoScreen, videoTextGraphics, languageText, areYouSure, areYouSureBtn;

    public void setValues()
    {
        if (englishActive)
        {
            titles = new string[] { "Pause", "Settings", "Sound", "Video Options", "Screen", "Graphics Quality", "Language" };
            mainText = new string[] { "Play", "Settings", "Exit", "Skip Tutorial" };
            pauseText = new string[] { "Exit the game", "Resume", "Settings", "Main Menu" };
            settingsText = new string[] { "Sound", "Video", "Language", "Back" };
            soundText = new string[] { "Back", "Mute", "Mute", "Volume" };
            videoOptions = new string[] { "Default", "Restart", "Back", "Screen", "Graphics"};
            videoTextGraphics = new string[] { "High", "Medium", "Low" };
            videoScreen = new string[] { "Back", "Fullscreen" , "Resolution", "Windowed Fullscreen"};
            languageText = new string[] { "Back", "English", "Catalan", "Spanish" };
            areYouSure = new string[] { "Back to Main Menu?", "Exit the game?", "Are you sure you want to set DEFAULT configuration?", "Are you sure you want to RESTART the game?" };
            areYouSureBtn = new string[] { "Yes", "No" };
        }

        else if (catalanActive)
        {
            titles = new string[] { "Pausa", "Opcions", "So", "Opcions de Video", "Pantalla", "Qualitat Gràfica", "Idioma" };
            mainText = new string[] { "Jugar", "Opcions", "Sortir", "Saltar Tutorial" };
            pauseText = new string[] {"Resumir", "Opcions", "Menú Principal", "Sortir" };
            settingsText = new string[] { "So", "Video", "Idioma", "Tornar" };
            soundText = new string[] { "Tornar", "Silenciar", "Silenciar", "Volum" };
            videoOptions = new string[] { "Per defecte", "Reiniciar", "Tornar", "Pantalla", "Gràfics" };
            videoTextGraphics = new string[] { "Alta", "Mitja", "Baixa", "Tornar" };
            videoScreen = new string[] { "Tornar", "Pantalla Completa" ,"Resolució", "Finestra Pantalla Completa"};
            languageText = new string[] { "Tornar", "Anglès", "Català", "Espanyol" };
            areYouSure = new string[] { "Vols tornar al menú principal?", "Sortir del joc?", "Estàs segur que vols tornar a la configuració per defecte?", "Estàs segur que vols tornar a començar?" };
            areYouSureBtn = new string[] { "Sí", "No" };
        }

        else if (spanishActive)
        {
            titles = new string[] { "Pausa", "Opciones", "Sonido", "Opciones de Video", "Pantalla", "Calidad Gráfica", "Idioma" };
            mainText = new string[] { "Jugar", "Opciones", "Salir", "Saltar Tutorial" };
            pauseText = new string[] { "Resumen", "Opciones", "Menú Principal", "Salir" };
            settingsText = new string[] { "Sonido", "Video", "Idioma", "Volver" };
            soundText = new string[] { "Volver", "Silenciar", "Silenciar", "Volumen"};
            videoOptions = new string[] { "Por defecto", "Reiniciar", "Volver", "Pantalla", "Calidad gràfica" };
            videoScreen = new string[] { "Volver", "Pantalla Completa", "Resolución", "Ventana Pantalla Completa" };
            videoTextGraphics = new string[] { "Alta", "Media", "Baja", "Volver" };
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

    public string[] getMainVideoOptionsText()
    {
        return videoOptions;
    }

    public string[] getVScreenText()
    {
        return videoScreen;
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

