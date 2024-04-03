using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RTSCharacterController : MonoBehaviour
{
    //Outlets
    Animator animator;
    NavMeshAgent navAgent;

    void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        animator.SetFloat("velocity", navAgent.velocity.magnitude);
    }

    public void setDestination(Vector3 targetPosition)
    {
        navAgent.destination = targetPosition;
    }
}
