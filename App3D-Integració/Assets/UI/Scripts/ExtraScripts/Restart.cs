using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGameUI()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGamePause()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
