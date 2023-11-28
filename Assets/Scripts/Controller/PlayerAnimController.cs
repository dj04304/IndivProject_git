using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController[] animController;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    
}
