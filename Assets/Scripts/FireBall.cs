using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10f;

    void Start()
    {
        Invoke("DestoryFireBall", lifetime);

        //Через сколько уничтожить объект, если он не соприкасается
        //Destroy(gameObject,5)
    }

    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestoryFireBall();
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }

    private void DestoryFireBall()
    {
        Destroy(gameObject);
    }
}
