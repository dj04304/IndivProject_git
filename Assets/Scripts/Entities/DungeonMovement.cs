using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMovement : MonoBehaviour
{
    private DungeonCharacterController _controller;
    
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 5f;

    private Vector2 _movementDirection = Vector2.zero;

    private Rigidbody2D _rigidbody;

    private enum Trigger
    {
        MOVE,
        IDLE
    }
    
    private Trigger _trigger;

    private void Awake()
    {
        _controller = GetComponent<DungeonCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
       
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _trigger = Trigger.IDLE;
        animator.SetTrigger(_trigger.ToString());
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {

        _trigger = direction != Vector2.zero ? Trigger.MOVE : Trigger.IDLE;
        animator.SetTrigger(_trigger.ToString());
       
        direction = direction * speed;
        _rigidbody.velocity = direction;
    }

}
