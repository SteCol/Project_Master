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
        //Storing the message. This is for when somethign will get updated every single frame.
        storedText = storedText + "\n " + addition;
    }

    public IEnumerator iDeb(string addition, int duration)
    {
        //Show the massage for "duration" frames. Meaning it'll add the "addition" string again once per frame for the next "duration" frames.
        for (int i = 0; i < duration; i++)
        {
            storedText = storedText + "\n " + addition;
            yield return null;
        }
    }

    void Update()
    {
        //FPS
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        msec = deltaTime * 1000.0f;
        fps = 1.0f / deltaTime;

        text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        Deb(text); //Store the framerate for this display loop.

        //Display all the messages
        debugText.text = ""; //Empty the already displayed text.
        debugText.text = storedText; //Show the new text stat was stored this frame.
        storedText = ""; //Empty the stored text to recieve new text.
    }
}
