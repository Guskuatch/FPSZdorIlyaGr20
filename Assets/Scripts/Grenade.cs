using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    public GameObject expolsionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);
    }

    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(expolsionPrefab);
        explosion.transform.position = transform.position;
    }
}
