using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPlayerAim : MonoBehaviour
{

    [SerializeField] private SpriteRenderer characterRenderer;

    private DungeonCharacterController _controller;
    // Start is called before the first frame update

    private void Awake()
    {
        _controller = GetComponent<DungeonCharacterController>();
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
        int userId = GameManager.Instance.userId;
        SetCharacterRenderer(userId);
    }

    /// <summary>
    /// userid�� ���� ĳ���� ����
    /// </summary>
    private void SetCharacterRenderer(int userId)
    {
        if (userId == 0)
        {
            // GameManager���� userId�� 0�̸� ù ��° Sprite�� characterRenderer�� �Ҵ�
            characterRenderer = transform.Find("CharacterSprite1").GetComponent<SpriteRenderer>();
        }
        else if (userId == 1)
        {
            // GameManager���� userId�� 1�̸� �� ��° Sprite�� characterRenderer�� �Ҵ�
            characterRenderer = transform.Find("CharacterSprite2").GetComponent<SpriteRenderer>();
        }
        else
        {
            Debug.LogWarning("Unsupported userId: " + userId);
        }
    }

    private void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        // vector�� ����
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;

    }
}
