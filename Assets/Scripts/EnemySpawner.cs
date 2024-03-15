using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public PlayerController player;
    //public PlayerHealth playerHealth;   
    public List<Transform> patrolPoints;

    public int enemiesMaxCount = 5;
    public float delay = 5;

    private List<Transform> _spawnerPoints;
    private List<EnemyAI> _enemies;

    private float _timeLastSpawned;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());

        // пишем так как private переменная
        _enemies = new List<EnemyAI>();
    }

    private void Update()
    {
        if (_enemies.Count >= enemiesMaxCount) return;
        if (Time.time - _timeLastSpawned < delay) return;

        CreateEnemy();
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        //enemy.playerHealth = playerHealth;
        _enemies.Add(enemy);
        _timeLastSpawned = Time.time;
    }
}
