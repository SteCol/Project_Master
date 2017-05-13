using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDepth : MonoBehaviour
{
    public GameObject target;
    public Vector3 startTransform;

    public Vector3 newTransform;


    void Start() {
        startTransform = transform.localPosition;
    }
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("CameraGimble").GetComponent<Matcher>().target;
        CheckBetweenCamera();
    }

    void CheckBetweenCamera()
    {
        RaycastHit hit;

        Vector3 fromPosition = target.transform.position;
        Vector3 toPosition = this.transform.position;
        Vector3 direction = toPosition - fromPosition;

        Debug.DrawRay(target.transform.position, direction, Color.red);

        if (Physics.Raycast(target.transform.position, direction, out hit))
        {
            newTransform.z++;
        }
        else if (newTransform.z < startTransform.z)
        {
            newTransform.z--;
        }

        transform.localPosition = new Vector3( 0,0,newTransform.z);
    }

}
