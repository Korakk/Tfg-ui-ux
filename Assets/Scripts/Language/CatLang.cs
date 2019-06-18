using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLang : MonoBehaviour
{
    private string[] MainText = new string[] { "Jugar", "Opcions", "Sortir" };
    private string[] PauseText = new string[] { "Sortir", "Resumir", "Opcions", "Menú Principal" };
    private string[] SettingsText = new string[] { "So", "Video", "Idioma", "Tornar" };
    private string[] SoundText = new string[] { "Tornar", "Silenciar", "Silenciar", "Volum" };
    private string[] VideoText = new string[] { "Tornar", "Pantalla Complerta", "Qualitat gràfica", "Resolució" };
    private string[] VideoTextGraphics = new string[] { "Alta", "Mitja", "Baixa" };
    private string[] LanguageText = new string[] { "Tornar", "Anglès", "Català", "Espanyol" };

    public CatLang() { }

    public string[] getMainText()
    {
        return MainText;
    }

    public string[] getPauseText()
    {
        return PauseText;
    }

    public string[] getSettingsText()
    {
        return SettingsText;
    }

    public string[] getSoundText()
    {
        return SoundText;
    }

    public string[] getMainVideoText()
    {
        return VideoText;
    }

    public string[] getVGraphicsText()
    {
        return VideoTextGraphics;
    }

    public string[] getLanguageText()
    {
        return LanguageText;
    }
}
