using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;

    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        PatrolUpdate();
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            PickNewPatrolPoint();
        }
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
}
