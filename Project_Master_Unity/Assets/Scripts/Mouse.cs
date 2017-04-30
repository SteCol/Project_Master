﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    [Header("Setup")]
    private Storage storage;

    [Header("For Mouse Input")]
    public float mouseSpeed;
    public GameObject nodGimble, yawGimble, rollGimble;
    public bool lockCamera;

    public float nod, yaw, roll;

    void Start()
    {
        Debug.Log("Starting in Mouse mode.");
        storage = GameObject.FindGameObjectWithTag("GameController").GetComponent<Storage>();

    }

    void Update()
    {
        PlayMouse();
        GetInfo();
        OnWorldChange();
    }

    void OnWorldChange()
    {
        if (storage.activeWorld != storage.checkWorld)
        {
            switch (storage.activeWorld)
            {
                case Worlds.Human:
                    Debug.Log("SWITCHED TO HUMAN WORLD");
                    //roll = roll + 180;
                    StartCoroutine(iRotateWorld(180));
                    break;
                case Worlds.Wolf:
                    Debug.Log("SWITCHED TO WORLF WORLD");
                    //roll = roll + 180;
                    StartCoroutine(iRotateWorld(180));
                    break;
            }
            storage.checkWorld = storage.activeWorld;
        }
    }

    public IEnumerator iRotateWorld(float _amount) {
        float amount = roll;
        lockCamera = true;
        for (float i = 0; i < 1.0f; i = i + 0.01f) {
            roll = Mathf.Lerp(amount, amount + _amount, i);
            yield return null;
        }
        lockCamera = false;
    }

    void PlayMouse()
    {
        //Nod and Yaw, with axis, based on active world (the mouse inputs need to be switched as well.

        if (storage.activeWorld == Worlds.Human && lockCamera == false)
        {
            nodGimble.transform.Rotate(0, Input.GetAxis("Mouse_X") * mouseSpeed, 0);
            yawGimble.transform.Rotate(-Input.GetAxis("Mouse_Y") * mouseSpeed, 0, 0);
        }
        else if (storage.activeWorld == Worlds.Wolf && lockCamera == false)
        {
            nodGimble.transform.Rotate(0, -Input.GetAxis("Mouse_X") * mouseSpeed, 0);
            yawGimble.transform.Rotate(-Input.GetAxis("Mouse_Y") * mouseSpeed, 0, 0);
        }

        //Roll, with mouse buttons.
        if (Input.GetKey(KeyCode.D))
            roll++;

        if (Input.GetKey(KeyCode.Q))
            roll--;

        //rollGimble.transform.Rotate(0, 0, roll);
        rollGimble.transform.eulerAngles = new Vector3(rollGimble.transform.eulerAngles.x, rollGimble.transform.eulerAngles.y, roll);
    }

    void GetInfo()
    {
        nod = nodGimble.transform.rotation.x;
        yaw = yawGimble.transform.rotation.y;
        //roll = rollGimble.transform.rotation.z;
    }
}
