using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCaster : MonoBehaviour
{
    public FireBall fireballPrefab;
    public Transform fireBallSourceTransform;
    void Start()
    {
        
    }

    private void Update()
    {
        FireballCaste();
    }

    private void FireballCaste()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, fireBallSourceTransform.position, fireBallSourceTransform.rotation);
        }
    }
}
