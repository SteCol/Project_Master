using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;


public class Gyro : MonoBehaviour
{

    public Text gyroDebug, gyroSliderText;
    public Slider gyroSpeedSlider;
    public float gyroSpeed;
    public float mouseSpeed;
    public bool recenter;

    public GameObject gimbleA, gimbleB;

    // Use this for initialization
    void Start()
    {

        if (!Application.isEditor)
        {
            StartGyro();
        }
        else
        {
            StartMouse();
        }

    }

    void StartGyro()
    {
        Debug.Log("Starting in Gyro mode.");


        Input.gyro.enabled = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        gyroSpeedSlider.value = gyroSpeed;

        //Screen.orientation = ScreenOrientation.AutoRotation;

    }

    void StartMouse() {
        Debug.Log("Starting in Mouse mode.");
    }
    
    // Update is called once per frame
    void Update()
    {

        if (!Application.isEditor)
        {
            PlayGyro();
        }
        else
        {
            PlayMouse();
        }
        
    }

    void PlayGyro() {
        gyroSpeed = gyroSpeedSlider.value;
        gyroSliderText.text = gyroSpeedSlider.value.ToString();
        gyroDebug.text = Input.gyro.rotationRateUnbiased.x.ToString("0,0") + " | " + Input.gyro.rotationRateUnbiased.y.ToString("0,0") + " | " + Input.gyro.rotationRateUnbiased.z.ToString("0,0");

        transform.Rotate(-Input.gyro.rotationRateUnbiased.x * gyroSpeed, -Input.gyro.rotationRateUnbiased.y * gyroSpeed, Input.gyro.rotationRateUnbiased.z * gyroSpeed);
        if (recenter)
        {
            Recenter();
            recenter = false;
        }
    }


    void PlayMouse() {
        gimbleA.transform.Rotate(0, Input.GetAxis("Mouse_X") * mouseSpeed, 0);
        gimbleB.transform.Rotate(Input.GetAxis("Mouse_Y") * mouseSpeed, 0, 0);

        gyroDebug.text = Input.GetAxis("Mouse_X").ToString("0,0") + " | " + Input.GetAxis("Mouse_Y").ToString("0,0");
    }

    public void Recenter()
    {
        this.transform.rotation = Quaternion.identity;
    }
}
