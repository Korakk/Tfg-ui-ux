using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LangsStorage : MonoBehaviour
{
    public string lang;

    private string[] mainText, pauseText, settingsText, soundText, VideoMainText, VideoGraphicsText, Language;

    public LangsStorage()
    {

    }

    public void Start()
    {
        setText();       
    }
    /*     public string[] MainText = new string[] { "Jugar", "Opciones", "Salir" };
    public string[] PauseText = new string[] { "Salir", "Resumir", "Opciones", "Menú Principal" };
    public string[] SettingsText = new string[] { "Sonido", "Video", "Idioma", "Volver" };
    public string[] SoundText = new string[] { "Volver", "Silenciar", "Silenciar", "Volumen" };
    public string[] VideoText = new string[] { "Volver", "Pantalla Completa", "Calidad gráfica", "Resolución" };
    public string[] VideoTextGraphics = new string[] { "Alta", "Media", "Baja" };
    public string[] LanguageText = new string[] { "Volver", "Inglés", "Catalán", "Español" }; */


    public void setText()
    {
        
        if (lang.Equals("ESP")){
            EspLang language = new EspLang();
            setTextESP(language);

        } else if (lang.Equals("ENG"))
        {
            EngLang language = new EngLang();
            setTextENG(language);

        } else if(lang.Equals("ESP"))
        {
            CatLang language = new CatLang();
            setTextCAT(language);

        }
    }

    public void setTextESP(EspLang language)
    {

    }

    public void setTextENG(EngLang language)
    {

    }

    public void setTextCAT(CatLang language)
    {

    }
    public void chooseLang(string lang)
    {
        if(lang == "ENG")
        {
            EngLang eng = new EngLang();

        }
    }
}
