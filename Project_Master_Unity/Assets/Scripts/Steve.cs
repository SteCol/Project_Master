using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steve : MonoBehaviour {

    [Header("Setup")]
    public float moveSpeed;

	void Update () {
        if (Input.GetKey(KeyCode.Z)) {
            this.transform.Translate(GameObject.FindGameObjectWithTag("MainCamera").transform.forward * moveSpeed * Time.deltaTime);
        }
	}
}
