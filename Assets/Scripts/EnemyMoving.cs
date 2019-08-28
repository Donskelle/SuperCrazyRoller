using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour {
    public Transform[] patrolPoints;

    int patrolPointIndex;
    float proximityBeforeChangeDestination = 0.5f;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    Transform comp;

    void Start () {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        comp = GetComponent<Transform> ();

        navMeshAgent.updatePosition = true;
        navMeshAgent.updateRotation = true;
        SetNextDestination ();
    }

    void Update () {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < proximityBeforeChangeDestination) {
            SetNextDestination ();
        }
    }

    void SetNextDestination () {
        navMeshAgent.SetDestination (patrolPoints[patrolPointIndex].position);
        patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Length;
    }
}