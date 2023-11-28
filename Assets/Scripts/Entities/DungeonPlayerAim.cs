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
    }

    private void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        // vectorÀÇ °¢µµ
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;

    }
}
