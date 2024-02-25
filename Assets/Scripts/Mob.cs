using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    public Transform Player;
    public float ViewAngle = 45;

    NavMeshAgent _navMeshAgent;

    void Start()
    {
        //_navMeshAgent = GetComponent<???>();
    }

    void Update()
    {
        if (CheckPlayer())
        {
            //_navMeshAgent.SetDestination(???);
        }
        else
        {
            Patrol();
        }
    }

    bool CheckPlayer()
    {
        Vector3 direction = Player.position - transform.position;
        //if (Vector3.Angle(transform.forward, direction) < ???)
        {
            RaycastHit hit;
            //if (Physics.Raycast(transform.position + Vector3.up, ???, out hit))
            {
                //if (hit.transform == ???)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Patrol()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(PatrolPoints[Random.Range(0, PatrolPoints.Count)].position);
        }
    }
}