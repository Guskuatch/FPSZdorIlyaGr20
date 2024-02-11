using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _charcterController;
    
    void Start()
    {
        _charcterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movement
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _charcterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }

    void FixedUpdate()
    {
        // Movement
        _charcterController.Move(_moveVector * speed * Time.deltaTime);

        // Fall and Jump
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _charcterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        // Stop fall fast

        if (_charcterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
