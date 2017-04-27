using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Steve : MonoBehaviour {

    [Header("Setup")]
    public GameObject Player;
    public float moveSpeed;
    private NavMeshAgent agent;
    public GameObject destination;
    public GameObject camera;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        agent = Player.GetComponent<NavMeshAgent>();
    }

    void Update () {
        if (Input.GetKey(KeyCode.Z)) {
            this.transform.Translate(camera.transform.forward * moveSpeed * Time.deltaTime);
        }

        NavMeshAgent();
	}

    void NavMeshAgent() {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("DOING NAVMESH");
            //Ray ray = forward;
            if (Physics.Raycast(transform.position, forward, out hit))
            {
                //Debug.Log("hit " + hit.transform.position.x + " | " + hit.transform.position.y + " | " + hit.transform.position.z);
                agent.SetDestination(hit.point);
            }
        }
    }
}
