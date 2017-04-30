using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;


public class Gyro : MonoBehaviour
{
    [Header("For Gyro Input")]
    public Text gyroDebug, gyroSliderText;
    public List<Slider> gyroSliders;
    public List<float> gyroValues;
    public float xSpeed, ySpeed, zSpeed;
    public bool recenter;

    void Start()
    {
        StartCoroutine(GameObject.FindGameObjectWithTag("GameController").GetComponent<Debugger>().iDeb("Starting In GYRO mode", 100));

        Input.gyro.enabled = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        for (int i = 0; i < gyroSliders.Count; i++)
        {
            gyroValues.Add(0.0f);
            gyroSliders[i].value= gyroValues[i];
        }

        //Screen.orientation = ScreenOrientation.AutoRotation;
    }


    void Update()
    {
        PlayGyro();
    }

    void PlayGyro()
    {

        for (int i = 0; i < gyroSliders.Count; i++)
        {
            gyroValues[i] = gyroSliders[i].value;
            gyroSliders[i].GetComponentInChildren<Text>().text = gyroSliders[i].value.ToString("00.00");
        }

        GameObject.FindGameObjectWithTag("GameController").GetComponent<Debugger>().Deb(Input.gyro.rotationRateUnbiased.x.ToString("0,0") + " | " + Input.gyro.rotationRateUnbiased.y.ToString("0,0") + " | " + Input.gyro.rotationRateUnbiased.z.ToString("0,0"));

        transform.Rotate(-Input.gyro.rotationRateUnbiased.x * xSpeed, -Input.gyro.rotationRateUnbiased.y * ySpeed, Input.gyro.rotationRateUnbiased.z * zSpeed);
        if (recenter)
        {
            Recenter();
            recenter = false;
        }
    }

    public void Recenter()
    {
        this.transform.rotation = Quaternion.identity;
    }
}
