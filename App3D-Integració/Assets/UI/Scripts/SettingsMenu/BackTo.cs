using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTo : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public bool fromPause;

    internal void sceneFromChecker(bool fromPause)
    {
        this.fromPause = fromPause;

    }

    public void sceneFrom()
    {
        if (fromPause == true)
        {
            MainMenu.SetActive(false);
            PauseMenu.SetActive(true);
            SettingsMenu.SetActive(false);
        }
        else
        {
            MainMenu.SetActive(true);
            PauseMenu.SetActive(false);
            SettingsMenu.SetActive(false);
        }
    }
}
