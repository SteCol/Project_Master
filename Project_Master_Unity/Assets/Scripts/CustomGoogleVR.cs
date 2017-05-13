using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google;

public class CustomGoogleVR : MonoBehaviour {

    void Awake() {
        GvrViewer.Instance.VRModeEnabled = false;
    }

    void Update () {
        if (GvrViewer.Instance.VRModeEnabled﻿ == true) {
            GvrViewer.Instance.ToggleDeviceVRMode(false);
        }

        if (Camera.main.fieldOfView != 60) {
            Camera.main.fieldOfView = 60;
        }

        if (GvrViewer.Instance.DistortionCorrection != GvrViewer.DistortionCorrectionMethod.None) {
            GvrViewer.Instance.DistortionCorrection = GvrViewer.DistortionCorrectionMethod.None;
        }

        //GvrViewer.Distortion.Undistorted;


        //this.transform.rotation = GvrController.Orientation;
	}
}
