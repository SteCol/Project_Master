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
        RayCast();
    }

    void RayCast()
    {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Physics.Raycast(transform.position, forward, out hit))
            {

                Debug.DrawRay(transform.position, hit.transform.position, Color.red);

                Vector3 point = new Vector3 (0,0,0);

                if (hit.transform.tag == "World_Human")
                {
                    storage.activeWorld = Worlds.Human; //Change the active world in Storage.
                    point = hit.point; //Set the new target for the player to move to.
                    //cameraGimble.GetComponent<Matcher>().target = player;
                }

                if (hit.transform.tag == "World_Wolf")
                {
                    storage.activeWorld = Worlds.Wolf; //Change the active world in Storage.
                    point = new Vector3(hit.point.x, -hit.point.y, hit.point.z); //Set the mirror target (on the human world).
                    //cameraGimble.GetComponent<Matcher>().target = playerCopy;
                }

                destinationIndicator.transform.position = point; //Move the target indicator the the actual target for some visual feedback.
                agent.SetDestination(point); //Set the NavMeshAgent to go to that point;

            }
        }
    }
}
