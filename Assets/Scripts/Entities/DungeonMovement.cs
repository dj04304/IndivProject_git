//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DungeonMovement : MonoBehaviour
//{
//    private DungeonCharacterController _controller;

//    [SerializeField] private RuntimeAnimatorController[] animController;
//    //[SerializeField] private Animator animator;
//    [SerializeField] private float speed = 5f;

//    private Vector2 _movementDirection = Vector2.zero;

//    private Animator _animator;
//    private Rigidbody2D _rigidbody;

//    private enum Trigger
//    {
//        MOVE,
//        IDLE
//    }

//    private Trigger _trigger;

//    private void Awake()
//    {
//        _controller = GetComponent<DungeonCharacterController>();
//        _rigidbody = GetComponent<Rigidbody2D>();
//        _animator = GetComponent<Animator>();

//    }

//    private void Start()
//    {
//        _controller.OnMoveEvent += Move;
//        _trigger = Trigger.IDLE;
//        _animator.SetTrigger(_trigger.ToString());
//    }

//    private void FixedUpdate()
//    {
//        ApplyMovement(_movementDirection);
//    }
//    void OnEnable()
//    {

//        int userId = GameManager.Instance.userId;

//        if (userId >= 0 && userId < animController.Length)
//        {

//        _animator.runtimeAnimatorController = animController[userId];

//        }
//        else
//        {
//            Debug.Log("�߸��� ����");
//        }
//    }

//    private void Move(Vector2 direction)
//    {
//        _movementDirection = direction;
//    }

//    private void ApplyMovement(Vector2 direction)
//    {

//        _trigger = direction != Vector2.zero ? Trigger.MOVE : Trigger.IDLE;

//        if (_animator != null)
//        {
//            _animator.SetTrigger(_trigger.ToString());
//        }
//        else
//        {
//            Debug.LogWarning("null ��.");
//        }

//        direction = direction * speed;
//        _rigidbody.velocity = direction;
//    }

//}

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

        // �ڽ� ������Ʈ�� �پ� �ִ� Animator���� ��������
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

    private void AnimatorTrigger(Trigger _trigger)
    {
        // _animator1�� _animator2 �� � ���� ������� ����
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
            Debug.LogWarning("Unsupported userId: " + GameManager.Instance.userId);
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    void OnEnable()
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

    private void SetActiveCharacterSprite(int userId)
    {
        if(userId == 0)
        {
            chSprite1.SetActive(userId == 0);
        }
        else if(userId == 1)
        {
            chSprite2.SetActive(userId == 1);
        }
        else
        {
            Debug.LogWarning("Unsupported userId: " + userId);
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
                Debug.LogWarning("Unsupported userId: " + userId);
            }
        }
        else
        {
            Debug.LogWarning("Invalid userId or Animator array index.");
        }
    }

}

