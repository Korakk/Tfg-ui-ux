using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspLang : MonoBehaviour
{
    private string[] MainText = new string[] { "Jugar", "Opciones", "Salir" };
    private string[] PauseText = new string[] { "Salir", "Resumir", "Opciones", "Menú Principal" };
    private string[] SettingsText = new string[] { "Sonido", "Video", "Idioma", "Volver" };
    private string[] SoundText = new string[] { "Volver", "Silenciar", "Silenciar", "Volumen" };
    private string[] VideoText = new string[] { "Volver", "Pantalla Completa", "Calidad gráfica", "Resolución" };
    private string[] VideoTextGraphics = new string[] { "Alta", "Media", "Baja" };
    private string[] LanguageText = new string[] { "Volver", "Inglés", "Catalán", "Español" };

    public EspLang() { }

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
