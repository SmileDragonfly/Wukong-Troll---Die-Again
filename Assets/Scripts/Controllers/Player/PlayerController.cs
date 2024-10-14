using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum PlayerState
{
    IDLE,
    FORWARD,
    BACKWARD,
    JUMP,
}

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    // Public members
    public float speed = 1f;
    public float jumpSpeed = 10f;

    // Private members
    Animator animator;
    PlayerState state;
    Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        state = PlayerState.IDLE;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlState();
        ControlMove();
    }

    private void ControlMove()
    {
        switch (state)
        {
            case PlayerState.FORWARD:
                Run(1); break;
            case PlayerState.BACKWARD: 
                Run(-1); break;
                break;
        }
    }

    private void ControlState()
    {
        float fHorizontal = Input.GetAxisRaw("Horizontal");
        if (fHorizontal > 0)
        {
            animator.SetTrigger("Run");
            state = PlayerState.FORWARD;
        }
        else if (fHorizontal < 0)
        {
            animator.SetTrigger("Run");
            state = PlayerState.BACKWARD;
        }
        else
        {
            animator.SetTrigger("Idle");
            state = PlayerState.IDLE;
        }
          
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Run(int nDirection)
    {
        rb.velocity = new Vector2(nDirection * speed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }
}
