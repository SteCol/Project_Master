using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationControl : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Close_Application"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("GameController").GetComponent<Debugger>().iDeb("Closing Application", 100));

            Application.Quit();
        }
    }
}
