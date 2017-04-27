using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [Header("For Mouse Input")]
    public float mouseSpeed;
    public GameObject gimbleA, gimbleB;

    void Start()
    {
        Debug.Log("Starting in Mouse mode.");
    }

    void Update()
    {
            PlayMouse();
    }

    void PlayMouse()
    {
        gimbleA.transform.Rotate(0, Input.GetAxis("Mouse_X") * mouseSpeed, 0);
        gimbleB.transform.Rotate(-Input.GetAxis("Mouse_Y") * mouseSpeed, 0, 0);

    }
}
