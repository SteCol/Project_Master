using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate( Input.acceleration);
        Debug.Log("Input.acceleration " + Input.acceleration.x.ToString("00.00") + " " + Input.acceleration.y.ToString("00.00") + " " + Input.acceleration.z.ToString("00.00"));
    }
}
