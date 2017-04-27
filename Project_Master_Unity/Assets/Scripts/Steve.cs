using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Steve : MonoBehaviour
{

    [Header("Setup")]
    public GameObject Player;
    public GameObject PlayerCopy;

    public float moveSpeed;
    private NavMeshAgent agent;
    public GameObject cameraGimble;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = Player.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.Z)) {
        //    this.transform.Translate(GetComponent<Camera>().transform.forward * moveSpeed * Time.deltaTime);
        //}

        NavMeshAgent();
    }

    void NavMeshAgent()
    {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Physics.Raycast(transform.position, forward, out hit))
            {
                if (hit.transform.tag == "World_Human")
                {
                    cameraGimble.GetComponent<Matcher>().target = Player;
                }

                if (hit.transform.tag == "World_Wolf")
                {
                    cameraGimble.GetComponent<Matcher>().target = PlayerCopy;
                }

                agent.SetDestination(hit.point);
            }
        }
    }
}
