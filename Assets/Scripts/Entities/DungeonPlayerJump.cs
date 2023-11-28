using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DungeonPlayerJump : MonoBehaviour
{
    private DungeonCharacterController _controller;
    
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D _rigidbody;

    private enum Trigger
    {
        JUMP
    }

    private Trigger _trigger;

    private void Awake()
    {
        _controller = GetComponent<DungeonCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(_controller != null )
        {
            _controller.OnJumpEvent += Jump;
        }

    }

    private void Jump()
    {

        animator.SetTrigger(_trigger.ToString());
        //_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        _rigidbody.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        //Debug.Log(_rigidbody.velocity);
        
    }

}
