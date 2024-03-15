using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100f;

    public PlayerProgress playerProgress;

    void Start()
    {
        //Используем так как один объект на сцене
        playerProgress = FindObjectOfType<PlayerProgress>();

        //Так работать не будет (указав скрипт в Инспекторе)
        //playerProgress = GetComponent<PlayerProgress>();
    }

    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);

        value -= damage;
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }    
}
