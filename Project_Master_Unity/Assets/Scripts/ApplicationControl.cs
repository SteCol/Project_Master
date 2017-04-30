using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationControl : MonoBehaviour
{
    public bool cursorLocked;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Close_Application") && !Application.isEditor)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("GameController").GetComponent<Debugger>().iDeb("Closing Application", 100));
            Application.Quit();
        }
        else if (Input.GetButtonDown("Close_Application") || Input.GetKeyDown(KeyCode.L)){
            cursorLocked = !cursorLocked;
            StartCoroutine(GameObject.FindGameObjectWithTag("GameController").GetComponent<Debugger>().iDeb("Cursor locked set to " + cursorLocked, 24));
        }
    }
}
