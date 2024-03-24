using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100f;
    public Animator animator;

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
            EnemyDeath();            
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }    

    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
