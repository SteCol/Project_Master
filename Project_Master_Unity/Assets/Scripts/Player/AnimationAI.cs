using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationAI : MonoBehaviour
{

    [Header("Setup")]
    public Animator animator;
    public NavMeshAgent nma;
    public Rigidbody rb;

    [Header("Controls")]
    public bool sitting;
    public bool moving;
    public float speed;


    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        nma = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = nma.velocity.magnitude;
        Debug.Log("rb velocity" + speed);
        animator.SetFloat("Speed", speed);

        if (speed > 0.0f)
            animator.SetBool("Moving", true);
        else
            animator.SetBool("Moving", false);

        animator.SetBool("Sitting", sitting);
    }
}
