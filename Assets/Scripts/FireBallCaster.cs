using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCaster : MonoBehaviour
{
    public float damage = 10;

    public FireBall fireballPrefab;
    public Transform fireBallSourceTransform;
    void Start()
    {
        
    }

    public AudioSource source;
    public AudioClip clip;

    private void Update()
    {
        FireballCaste();
    }

    private void FireballCaste()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(fireballPrefab, fireBallSourceTransform.position, fireBallSourceTransform.rotation);
            fireball.damage = damage;

            source.PlayOneShot(clip);
        }
    }
}
