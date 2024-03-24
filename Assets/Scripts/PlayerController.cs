using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    public Animator animator;
    public AudioSource walkSound;
    public AudioClip clipWalk;

    public float minMoveDistance = 1f;

    private Vector3 _previousPosition;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _charcterController;

    void Start()
    {
        _charcterController = GetComponent<CharacterController>();
        _previousPosition = transform.position;
    }

    void Update()
    {
        MovementUpdate();
        JumpUpdate();
        
    }

    void FixedUpdate()
    {
        // Movement
        _charcterController.Move(_moveVector * speed * Time.deltaTime);
        PlaySound();

        // Fall and Jump
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _charcterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        // Stop fall fast
        if (_charcterController.isGrounded)
        {
            _fallVelocity = 0;
            animator.SetBool("isGrounded", true);
        }
    }    

    private void PlaySound()
    {
        //walkSound.Play();

        float moveDistance = Vector3.Distance(transform.position, _previousPosition);

        if (moveDistance >= minMoveDistance)
        {
            walkSound.PlayOneShot(clipWalk);

            _previousPosition = transform.position;
        }
    }

    private void MovementUpdate()
    {
        // Movement
        _moveVector = Vector3.zero;
        var runDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            runDirection = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDirection = 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            runDirection = 4;
        }
        //if (runDirection > 0)
        //    {
        //        Invoke("PlaySound", 2);
        //    }
            
        //else walkSound.Stop();

        //Old version
        //if (_moveVector != Vector3.zero)
        //{
        //    animator.SetBool("isRun", true);
        //}
        //else
        //{
        //    animator.SetBool("isRun", false);
        //}

        animator.SetInteger("run direction", runDirection);
    }

    private void JumpUpdate()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _charcterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            animator.SetBool("isGrounded", false);
        }
    }
}
