using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public Transform Player;
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    public PlayerHealth _playerHealth;
    private bool _isPlayerNoticed;

    public float MinDetectDistance = 3;
    public float Damage = 10;

    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
        
        //или так _playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        //_playerHealth = _playerHealth.GetComponent<PlayerHealth>();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        //OR AND _playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
        AttackUpdate();
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                //Отнять от здоровья игрока Damage в секунду
                _playerHealth.TakeDamage(Damage * Time.deltaTime);                
            }
        }        
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if ((Vector3.Angle(transform.forward, direction) < viewAngle) || (Vector3.Distance(transform.position, Player.position) < MinDetectDistance))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;                    
                }
            }
        }
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
        
    }

    private void PickNewPatrolPoint()
    {
        //if (patrolPoints != null)
        //or just check this (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}


//{
    //public List<Transform> PatrolPoints;
    //public Transform Player;
    //public float ViewAngle = 90;
    //public float MinDetectDistance = 3;
    //public float Damage = 10;

    //NavMeshAgent _navMeshAgent;
    //PlayerHealth _playerHealth;

    //void Start()
    //{
    //    _navMeshAgent = GetComponent<NavMeshAgent>();
        //сохранить ссылку на PlayerHealth через GetComponent
        //_playerHealth = ???;
   // }

    //void Update()
    //{
    //    if (CheckPlayer())
    //    {
    //        _navMeshAgent.SetDestination(Player.position);
    //        //Если оставшееся расстояние меньше или равно, чем дистанция остановки
    //        //if (_navMeshAgent.remainingDistance <= ???)
    //        {
    //            //Отнять от здоровья игрока Damage в секунду
    //            //_playerHealth.TakeDamage(???));
    //        }
    //    }
    //    else
    //    {
    //        Patrol();
    //    }
    //}

    //bool CheckPlayer()
    //{
    //    Vector3 direction = Player.position - transform.position;
    //    if (Vector3.Angle(transform.forward, direction) < ViewAngle || Vector3.Distance(transform.position, Player.position) < MinDetectDistance)
    //    {
    //        RaycastHit hit;
    //        if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
    //        {
    //            if (hit.transform == Player)
    //            {
    //                return true;
    //            }
    //        }
    //    }
    //    return false;
    //}

    //void Patrol()
    //{
    //    if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
    //    {
    //        _navMeshAgent.SetDestination(PatrolPoints[Random.Range(0, PatrolPoints.Count)].position);
    //    }
    //}
//}