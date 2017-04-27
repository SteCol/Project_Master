using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [Header("For Mouse Input")]
    public float mouseSpeed;
    public GameObject nodGimble, yawGimble, rollGimble;

    public float nod, yaw, roll;

    void Start()
    {
        Debug.Log("Starting in Mouse mode.");
    }

    void Update()
    {
        PlayMouse();
        GetInfo();
    }

    void PlayMouse()
    {
        nodGimble.transform.Rotate(0, Input.GetAxis("Mouse_X") * mouseSpeed, 0);
        yawGimble.transform.Rotate(-Input.GetAxis("Mouse_Y") * mouseSpeed, 0, 0);

        rollGimble.transform.Rotate(0, 0, roll);

    }

    void GetInfo() {
        nod = nodGimble.transform.rotation.x;
        yaw = yawGimble.transform.rotation.y;
        //roll = rollGimble.transform.rotation.z;
    }
}
