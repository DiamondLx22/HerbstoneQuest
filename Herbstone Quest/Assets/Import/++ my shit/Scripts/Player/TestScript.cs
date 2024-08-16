using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScript : MonoBehaviour
{
    private PlayerController playerController;
    private InputAction waterAction;
    
    public bool isWatering;
    public float dirX;
    public float dirY;   
    
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        //waterAction = playerController.inputActions.Player.Water;

    }

    public void Subscribe()
    {
        waterAction = playerController.inputActions.Player.Water;
        waterAction.performed += OnWateringStarted;
        waterAction.canceled += OnWateringStopped;
        print("subscribed");
    }
    
    public void Unsubscribe()
    {
        waterAction.performed -= OnWateringStarted;
        waterAction.canceled -= OnWateringStopped;
    }
    
    private void OnWateringStarted(InputAction.CallbackContext context)
    {
        Debug.Log("testOOO");
        
    }

    private void OnWateringStopped(InputAction.CallbackContext context)
    {
        Debug.Log("test2EEEE");
    }
}
