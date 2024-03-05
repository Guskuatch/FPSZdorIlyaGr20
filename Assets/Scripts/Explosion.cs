using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage = 50;
    public float maxSize = 5;
    public float speed = 1;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.localScale.x < maxSize)
        {
            transform.localScale += Vector3.one * Time.deltaTime * speed;
        }
        else
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
}
