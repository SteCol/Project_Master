using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matcher : MonoBehaviour {

    [Header("Setup")]
    public GameObject target;

	void Start () {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        this.transform.position = target.transform.position;
	}
}
