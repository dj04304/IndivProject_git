using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : DungeonCharacterController
{
    public GameObject uiPanel;
    private Camera _camera;
   

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        if(uiPanel.activeSelf == false)
        {
            Vector2 moveInput = value.Get<Vector2>().normalized;
            CallMoveEvent(moveInput);
        }
        else if(uiPanel.activeSelf == true)
        {
            Vector2 moveInput = Vector2.zero;
            CallMoveEvent(moveInput);
        }
        
    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized; 
    
        if(newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }
    public void OnAttack(InputValue value)
    {

    }
    public void OnJump()
    {
        CallJumpEvent();
        Debug.Log("Jump");
    }

}
