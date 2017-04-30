//ADAPTED FROM https://gamedev.stackexchange.com/questions/67839/is-there-a-way-to-display-navmesh-agent-path-in-unity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrawNavPath : MonoBehaviour
{
    public LineRenderer lineRenderer;  //to hold the line Renderer
    public Transform target; //to hold the transform of the target
    public NavMeshAgent agent; //to hold the agent of this gameObject

    public void DrawPath()
    {
        lineRenderer = GetComponent<LineRenderer>(); //get the line renderer
        agent = GetComponent<NavMeshAgent>(); //get the agent
        StartCoroutine(iGetPath());
    }

    IEnumerator iGetPath()
    {
        lineRenderer.SetPosition(0, transform.position); //set the line's origin
        agent.SetDestination(target.position); //create the path
        yield return null; //wait for the path to generate

        DrawPath(agent.path);

        //agent.Stop();//add this if you don't want to move the agent
    }

    void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            return;

        lineRenderer.SetVertexCount(path.corners.Length); //set the array of positions to the amount of corners

        for (var i = 1; i < path.corners.Length; i++)
        {
            lineRenderer.SetPosition(i, path.corners[i]); //go through each corner and set that to the line renderer's position
        }
    }
}