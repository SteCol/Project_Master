using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Steve : MonoBehaviour
{

    [Header("Setup")]
    public GameObject player;
    public GameObject playerCopy;
    public GameObject destinationIndicator;
    private Storage storage;

    public float moveSpeed;
    private NavMeshAgent agent;
    public GameObject cameraGimble;

    void Start()
    {
        storage = GameObject.FindGameObjectWithTag("GameController").GetComponent<Storage>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = player.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
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
                Vector3 point = new Vector3 (0,0,0);

                if (hit.transform.tag == "World_Human")
                {
                    storage.activeWorld = Worlds.Human;
                    point = hit.point;
                    //cameraGimble.GetComponent<Matcher>().target = player;
                }

                if (hit.transform.tag == "World_Wolf")
                {
                    storage.activeWorld = Worlds.Wolf;
                    point = new Vector3(hit.point.x, -hit.point.y, hit.point.z);
                    //cameraGimble.GetComponent<Matcher>().target = playerCopy;
                }

                destinationIndicator.transform.position = point;
                agent.SetDestination(point);
            }
        }
    }
}
