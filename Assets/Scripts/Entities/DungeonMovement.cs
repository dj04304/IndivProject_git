using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMovement : MonoBehaviour
{
    private DungeonCharacterController _controller;

    [SerializeField] private GameObject chSprite1;
    [SerializeField] private GameObject chSprite2;
    [SerializeField] private RuntimeAnimatorController[] animControllers;
    [SerializeField] private float speed = 5f;

    private Vector2 _movementDirection = Vector2.zero;

    private Animator _animator1; // ù ��° Animator
    private Animator _animator2; // �� ��° Animator
    private Rigidbody2D _rigidbody;

    // MOVE�� IDLE�� enum�����ְ� �ִϸ��̼ǿ��� setTrigger�뵵�� ���
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

        // �ڽ� ������Ʈ(CharacterSprite1, 2)�� �پ� �ִ� Animator���� ��������
        _animator1 = transform.Find("CharacterSprite1").GetComponent<Animator>();
        _animator2 = transform.Find("CharacterSprite2").GetComponent<Animator>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _trigger = Trigger.IDLE;
        // _animator1�� _animator2 �� � ���� ������� ����
        AnimatorTrigger(_trigger);
    }

    /// <summary>
    /// // _animator1�� _animator2 �� � ���� ������� ����
    /// </summary>
    private void AnimatorTrigger(Trigger _trigger)
    {
        
        if (GameManager.Instance.userId == 0)
        {
            _animator1.SetTrigger(_trigger.ToString());
        }
        else if (GameManager.Instance.userId == 1)
        {
            _animator2.SetTrigger(_trigger.ToString());
        }
        else
        {
            Debug.Log("userId: " + GameManager.Instance.userId);
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void OnEnable()
    {
        int userId = GameManager.Instance.userId;
        SetActiveCharacterSprite(userId);
        ChooseAnimatorController(userId);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        _trigger = direction != Vector2.zero ? Trigger.MOVE : Trigger.IDLE;
        //Debug.Log("Trigger: " + _trigger.ToString()); // ������� ���� ��� �߰�

        // � Animator�� ������� ����
        if (GameManager.Instance.userId == 0)
        {
            _animator1.SetTrigger(_trigger.ToString());
        }
        else if(GameManager.Instance.userId == 1)
        {
            _animator2.SetTrigger(_trigger.ToString());
        }

        direction = direction * speed;
        _rigidbody.velocity = direction;
    }

    /// <summary>
    /// ActiveCharacterSprite
    /// </summary>
    private void SetActiveCharacterSprite(int userId)
    {

        //�Ҵ���� CharterSprite�� � Sprite�� Ȱ��ȭ��ų�� ����
        if (userId == 0)
        {
            chSprite1.SetActive(userId == 0);
        }
        else if(userId == 1)
        {
            chSprite2.SetActive(userId == 1);
        }
        else
        {
            Debug.Log("userId: " + userId);
        }
       
    }

    /// <summary>
    /// animatorControllers
    /// </summary>
    private void ChooseAnimatorController(int userId)
    {
        // GameManager.Instance.userId�� ������ Animator�� ����
        if (userId >= 0 && userId < animControllers.Length)
        {
            if (userId == 0)
            {
                _animator1.runtimeAnimatorController = animControllers[userId];
            }
            else if (userId == 1)
            {
                _animator2.runtimeAnimatorController = animControllers[userId];
            }
            else
            {
                Debug.Log("userId: " + userId);
            }
        }
        else
        {
            Debug.Log("userId: " + userId);
        }
    }

}

