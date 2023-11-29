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

    private Animator _animator1; // 첫 번째 Animator
    private Animator _animator2; // 두 번째 Animator
    private Rigidbody2D _rigidbody;

    // MOVE와 IDLE을 enum으로주고 애니메이션에서 setTrigger용도로 사용
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

        // 자식 오브젝트(CharacterSprite1, 2)에 붙어 있는 Animator들을 가져오기
        _animator1 = transform.Find("CharacterSprite1").GetComponent<Animator>();
        _animator2 = transform.Find("CharacterSprite2").GetComponent<Animator>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _trigger = Trigger.IDLE;
        // _animator1과 _animator2 중 어떤 것을 사용할지 선택
        AnimatorTrigger(_trigger);
    }

    /// <summary>
    /// // _animator1과 _animator2 중 어떤 것을 사용할지 선택
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
        //Debug.Log("Trigger: " + _trigger.ToString()); // 디버깅을 위한 출력 추가

        // 어떤 Animator를 사용할지 선택
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

        //할당받은 CharterSprite중 어떤 Sprite를 활성화시킬지 선택
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
        // GameManager.Instance.userId와 연관된 Animator를 선택
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

