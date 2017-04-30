using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    public Text debugText;
    public Text dateText;
    public float version;
    public string storedText;
    public float deltaTime;
    public float msec;
    public float fps;
    public string text;

    void Awake()
    {
        //Time
        dateText.text = "Project_Master v" + version + "\n" + System.DateTime.Now.ToString("dd/MM/yyyy");
    }

    public void Deb(string addition)
    {
        //Storing the message
        storedText = storedText + "\n " + addition;
    }

    void Update()
    {
        //FPS
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        msec = deltaTime * 1000.0f;
        fps = 1.0f / deltaTime;

        text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        Deb(text);

        //Display all the messages
        debugText.text = "";
        debugText.text = storedText;
        storedText = "";
    }
}
