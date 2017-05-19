using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Companion : MonoBehaviour {
    public GameObject target;

	void Update () {
        this.GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
	}
}
