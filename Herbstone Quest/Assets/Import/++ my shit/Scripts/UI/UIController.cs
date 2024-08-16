using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    #region Private Variables
    private Player_InputActions inputActions;
    private InputAction inventoryAction;
    private InventoryManager inventoryManager;
    private GameController gameController;
    
    #endregion
    
    #region Public Variables
    public Animator[] anim;
    public Rigidbody2D rb;
    #endregion

    #region Inspector

    [SerializeField] private GameObject inventoryContainer;

    #endregion
    
    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        gameController = FindObjectOfType<GameController>();
        inputActions = new Player_InputActions();
        inventoryAction = inputActions.UI.Inventory;
    }
    
    private void OnEnable()
    {
        EnableInput();
        inventoryContainer.SetActive(false);
        inventoryAction.performed += OpenInventory;
    }
    
    private void OnDisable()
    {
        inputActions.Disable();
        inventoryAction.performed -= OpenInventory;
    }
    public void EnableInput()
    {
        inputActions.Enable();
    }

    public void DisableInput()
    {
        inputActions.Disable();
    }
    
    #region UI Controlling

    private void OpenInventory(InputAction.CallbackContext ctx)
    {
        inventoryContainer.SetActive(!inventoryContainer.activeSelf);
        inventoryManager.RefreshInventory();

        if (inventoryContainer.activeSelf)
        {
            gameController.StartInventory();
        }
        else
        {
            gameController.EndInventory();
        }
    }
    
    #endregion
}
