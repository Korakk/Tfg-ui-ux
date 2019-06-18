using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngLang : MonoBehaviour
{
    private string[] MainText = new string[] { "Play", "Settings", "Exit" };
    private string[] PauseText = new string[] { "Exit the game", "Resume", "Settings", "Main Menu" };
    private string[] SettingsText = new string[] { "Sound", "Video", "Language", "Back" };
    private string[] SoundText = new string[] { "Back", "Mute", "Mute", "Volume" };
    private string[] VideoText = new string[] { "Back", "Fullscreen", "Graphics Quality", "Resolution" };
    private string[] VideoTextGraphics = new string[] { "High", "Medium", "Low" };
    private string[] LanguageText = new string[] { "Back", "English", "Catalan", "Spanish" };

    public EngLang() { }

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
