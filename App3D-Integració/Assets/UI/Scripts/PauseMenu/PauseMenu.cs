using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseUIMenu, RightHand, LeftHand, AppHands, Uicamera, Appcamera;

    public void Resume()
    {
        Uicamera.SetActive(false);
        PauseUIMenu.SetActive(false);
        RightHand.SetActive(false);
        LeftHand.SetActive(false);

        AppHands.SetActive(true);
        Appcamera.SetActive(true);
        GameIsPaused = false;

    }

    public void Pause()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //Loads previous scene (UI)
    }
}
