using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class worldSwitch : MonoBehaviour
{

    [Header("EXECUTING IN EDIT MODE")]

    [Header("Establishing")]
    public Color color1;
    public Color color2;

    public GameObject gimblePos;
    public GameObject gimbleRot;

    [Header("Controls")]
    public bool setPos1;
    public bool setPos2;

    [Header("Calculating")]
    public bool world1;
    public bool world2;
    public float zAngle;
    //public int firstNum, secondNum;
    public int startFrom, threshHold;

    public Vector3 world1Location, world2Location;
    public float locationValue;

    void Update()
    {
        zAngle = gimbleRot.transform.rotation.eulerAngles.z;

        SetPos();

        if (zAngle > 270 || zAngle < 90)
        {
            world1 = true;
            world2 = false;

        }
        else
        {
            world1 = false;
            world2 = true;
        }
        ChangeColor();

        CameraPos();
    }

    void SetPos() {
        if (setPos1)
        {
            world1Location = gimblePos.transform.position;
            setPos1 = false;
        }
        if (setPos2)
        {
            world2Location = gimblePos.transform.position;
            setPos2 = false;
        }
    }

    void ChangeColor()
    {
        if (world1)
        {
            Camera.main.backgroundColor = color1;
        }

        if (world2)
        {
            Camera.main.backgroundColor = color2;
        }
    }

    void CameraPos()
    {
        if (world1 && locationValue < 1)
        {
            locationValue = locationValue + 1 * Time.deltaTime;
            gimblePos.transform.position = Vector3.Slerp(world2Location, world1Location, locationValue);

        }
        else if (world2 && locationValue > 0)
        {
            locationValue = locationValue - 1 * Time.deltaTime;
            gimblePos.transform.position = Vector3.Slerp(world2Location, world1Location, locationValue);
        }
    }
}
