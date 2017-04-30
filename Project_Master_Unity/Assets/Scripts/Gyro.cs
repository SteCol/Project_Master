using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;


public class Gyro : MonoBehaviour
{
    [Header("For Gyro Input")]
    public Text gyroDebug, gyroSliderText;
    public Slider gyroSpeedSlider;
    public float gyroSpeed;
    public bool recenter;

    void Start()
    {
        StartCoroutine(GameObject.FindGameObjectWithTag("GameController").GetComponent<Debugger>().iDeb("Starting In GYRO mode", 100));

        Input.gyro.enabled = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        gyroSpeedSlider.value = gyroSpeed;

        //Screen.orientation = ScreenOrientation.AutoRotation;
    }

    
    void Update()
    {
            PlayGyro();
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

    public void Recenter()
    {
        this.transform.rotation = Quaternion.identity;
    }
}
