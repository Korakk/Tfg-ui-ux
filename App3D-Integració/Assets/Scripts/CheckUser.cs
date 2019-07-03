using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUser : MonoBehaviour
{
    string message;

    // Start is called before the first frame update
    void Start()
    {
        message = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentUserTracker.CurrentUser != 0)
            message = "User found";
        else
            message = "User not found";
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.skin.label.fontSize = 50;
        GUILayout.Label(message);
    }
}
