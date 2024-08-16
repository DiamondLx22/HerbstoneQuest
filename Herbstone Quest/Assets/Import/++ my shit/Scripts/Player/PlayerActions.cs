using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private PlayerController playerController;
    private InputAction waterAction;
    private InputAction axeAttackAction;

    public Animator[] animPlayer;
    public Animator[] animWeapon;
    public Animator[] animWeaponEffects;
    
    public bool isWatering;
    public bool isAxeAttacking;
    public float dirX;
    public float dirY;   

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        //waterAction = playerController.waterAction;
        Debug.Log(waterAction);
    }

    public void Subscribe()
    {
        waterAction = playerController.inputActions.Player.Water;
        waterAction.performed += OnWateringStarted;
        waterAction.canceled += OnWateringStopped;
        
        axeAttackAction = playerController.inputActions.Player.AxeAttack;
        axeAttackAction.performed += OnAxeAttackingStarted;
        axeAttackAction.canceled += OnAxeAttackingStopped;
        print("subscribed");
    }

    public void Unsubscribe()
    {
        waterAction = playerController.inputActions.Player.Water;
        waterAction.performed -= OnWateringStarted;
        waterAction.canceled -= OnWateringStopped;
        
        axeAttackAction = playerController.inputActions.Player.AxeAttack;
        axeAttackAction.performed -= OnAxeAttackingStarted;
        axeAttackAction.canceled -= OnAxeAttackingStopped;
    }

    private void OnWateringStarted(InputAction.CallbackContext context)
    {
        Debug.Log("test1");
        playerController.ResetIdleTimer();
        //playerController.DisableInput();
        isWatering = true;
        UpdateAnimations();
    }

    private void OnWateringStopped(InputAction.CallbackContext context)
    {
        Debug.Log("test2");
        playerController.ResetIdleTimer();
        //playerController.EnableInput();
        isWatering = false;
        UpdateAnimations();
    }
    
    private void OnAxeAttackingStarted(InputAction.CallbackContext context)
    {
        Debug.Log("test3");
        playerController.ResetIdleTimer();
        //playerController.DisableInput();
        isAxeAttacking = true;
        UpdateAnimations();
    }
    
    private void OnAxeAttackingStopped(InputAction.CallbackContext context)
    {
        Debug.Log("test4");
        playerController.ResetIdleTimer();
        //playerController.DisableInput();
        isAxeAttacking = false;
        UpdateAnimations();
    }
    
    void LateUpdate()
    {
        UpdateAnimations();
    }

    public void UpdateAnimations()
    {
        for (int i = 0; i < animWeapon.Length; i++)
        {
            animWeapon[i].SetFloat("dirX", dirX);
            animWeapon[i].SetFloat("dirY", dirY);
            animWeapon[i].SetBool("isWatering", isWatering);
            animWeapon[i].SetBool("isAxeAttacking", isAxeAttacking);
            
            animWeaponEffects[i].SetFloat("dirX", dirX);
            animWeaponEffects[i].SetFloat("dirY", dirY);
            animWeaponEffects[i].SetBool("isAxeAttacking", isAxeAttacking);
        }

        for (int i = 0; i < animPlayer.Length; i++)
        {
            animPlayer[i].SetBool("isWatering", isWatering);
            animPlayer[i].SetBool("isAxeAttacking", isAxeAttacking);
        }
    }
}