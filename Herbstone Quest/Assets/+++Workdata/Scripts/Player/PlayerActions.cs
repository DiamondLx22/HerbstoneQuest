using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private PlayerController playerController;

    private InputAction rangeAttackAction;
    private InputAction waterAction;
    //private InputAction axeAttackAction;

    public Animator[] animPlayer;
    //public Animator[] animWeapon;
   // public Animator[] animWeaponEffects;
    
    public bool isWatering;
    //public bool isAxeAttacking;
    public bool isAttacking;
    public float AttackType;
    public float StaffID;
    public float AttackID;
    public float dirX;
    public float dirY;   
    
    
    public Player_InputActions inputActions;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    
        if (playerController == null)
        {
            Debug.LogError("playerController is still null after GetComponent in Awake!");
        }
        else
        {
            Debug.Log("playerController successfully retrieved in Awake.");
        }

        inputActions = new Player_InputActions();
        //inputActions = new Player_InputActions();
        //playerController = GetComponent<PlayerController>();
        //playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //waterAction = playerController.waterAction;
        Debug.Log(waterAction);
        Debug.Log(inputActions.Player.RangeAttack);
    }

    public void Subscribe()
    {
        waterAction = playerController.inputActions.Player.Water;
        waterAction.performed += OnWateringStarted;
        waterAction.canceled += OnWateringStopped;
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("playerController is null in Subscribe!");
        }
        else
        {
            Debug.Log("playerController is not null in Subscribe.");
            rangeAttackAction = inputActions.Player.RangeAttack;
            Debug.Log(rangeAttackAction != null ? "RangeAttack is valid." : "RangeAttack is null!");
            
            rangeAttackAction.performed += OnRangeAttackingStarted;
            rangeAttackAction.canceled += OnRangeAttackingStopped;
        }
        
        //axeAttackAction = playerController.inputActions.Player.AxeAttack;
        //axeAttackAction.performed += OnAxeAttackingStarted;
        //axeAttackAction.canceled += OnAxeAttackingStopped;
        print("subscribed");
    }

    public void Unsubscribe()
    {
        waterAction = playerController.inputActions.Player.Water;
        waterAction.performed -= OnWateringStarted;
        waterAction.canceled -= OnWateringStopped;
        
        rangeAttackAction = playerController.inputActions.Player.RangeAttack;
        rangeAttackAction.performed -= OnRangeAttackingStarted;
        rangeAttackAction.canceled -= OnRangeAttackingStopped;
        
        //axeAttackAction = playerController.inputActions.Player.AxeAttack;
        //axeAttackAction.performed -= OnAxeAttackingStarted;
        //axeAttackAction.canceled -= OnAxeAttackingStopped;
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
        //isAxeAttacking = true;
        UpdateAnimations();
    }
    
    private void OnAxeAttackingStopped(InputAction.CallbackContext context)
    {
        Debug.Log("test4");
        playerController.ResetIdleTimer();
        //playerController.DisableInput();
        //isAxeAttacking = false;
        UpdateAnimations();
    }

    #region RangeAttack
    
    private void OnRangeAttackingStarted(InputAction.CallbackContext context)
    {
        Debug.Log("test3");
        playerController.ResetIdleTimer();
        //playerController.DisableInput();
        isAttacking = true;
        UpdateAnimations();
    }
    
    private void OnRangeAttackingStopped(InputAction.CallbackContext context)
    {
        Debug.Log("test4");
        playerController.ResetIdleTimer();
        //playerController.DisableInput();
        isAttacking = false;
        UpdateAnimations();
    }
    
    #endregion
    
    void LateUpdate()
    {
        UpdateAnimations();
    }

    public void UpdateAnimations()
    {
        //for (int i = 0; i < animWeapon.Length; i++)
        {
            //animWeapon[i].SetFloat("dirX", dirX);
            //animWeapon[i].SetFloat("dirY", dirY);
            //animWeapon[i].SetBool("isWatering", isWatering);
            //animWeapon[i].SetBool("isAxeAttacking", isAxeAttacking);
            
            //animWeaponEffects[i].SetFloat("dirX", dirX);
            //animWeaponEffects[i].SetFloat("dirY", dirY);
            //animWeaponEffects[i].SetBool("isAxeAttacking", isAxeAttacking);
        }

        for (int i = 0; i < animPlayer.Length; i++)
        {
            animPlayer[i].SetBool("isWatering", isWatering);
            animPlayer[i].SetBool("isAttacking", isAttacking);
        }
    }
}