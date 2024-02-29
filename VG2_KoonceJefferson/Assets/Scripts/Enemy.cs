using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Outlets
    NavMeshAgent navAgent;

    //Config
    public Transform target;
    public Transform patrolRoute;
    public Transform priorityTarget;

    //State Tracking
    int patrolIndex;
    public int chaseDistance;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (patrolRoute)
        {
            target = patrolRoute.GetChild(patrolIndex);

            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= 1.5f)
            {
                patrolIndex++;
                if (patrolIndex >= patrolRoute.childCount)
                {
                    patrolIndex = 0;
                }
            }
        }

        if (priorityTarget)
        {
            float priorityTargetDistance = Vector3.Distance(transform.position, priorityTarget.position);

            if(priorityTargetDistance <= chaseDistance)
            {
                target = priorityTarget;
                GetComponent<Renderer>().material.color = Color.red;
            } else
            {
                GetComponent<Renderer>().material.color = Color.white;
            }
        }

        if (target)
        {
            navAgent.SetDestination(target.position);
        }
    }
}
