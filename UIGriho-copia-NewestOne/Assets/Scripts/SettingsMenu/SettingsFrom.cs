using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsFrom : MonoBehaviour
{
    public BackTo backTo;
    public bool fromPause = true;

    public void fromPauseMenu()
    {
        backTo.sceneFromChecker(fromPause);
    }

    public void fromMainMenu()
    {
        backTo.sceneFromChecker(!fromPause);
    }
}
