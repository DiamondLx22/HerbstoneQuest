using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Private Variables
    public Player_InputActions inputActions;
    private InputAction moveAction;
    private InputAction runAction;
    private InputAction interactAction;
    
    private Vector2 moveInput;
    private bool isRunning;
    
    public List<Interactable> selectedInteractables;
    private float idleTimer;
    #endregion

    #region Public Variables
    public Animator[] anim;
    public Rigidbody2D rb;
    public float walkSpeed;
    public float runSpeed;
    public float idleTimeThreshold = 10.0f; // Time in seconds to become impatient

    // Reference to PlayerActions script
    public PlayerActions playerAction;
    #endregion

    #region Unity Event Functions

    private void Awake()
    {
        inputActions = new Player_InputActions();
        moveAction = inputActions.Player.Move;
        runAction = inputActions.Player.Run;
        interactAction = inputActions.Player.Interact;
        if (playerAction == null)
        {
            playerAction = GetComponent<PlayerActions>(); // or another method to retrieve the component
        }
    }

    private void OnEnable()
    {
        EnableInput();
        moveAction.performed += Move;
        moveAction.canceled += Move;

        runAction.performed += StartRunning;
        runAction.canceled += StopRunning;

        interactAction.performed += Interact;
        if (playerAction == null)
        {
            Debug.LogError("playerAction is null in OnEnable!");
        }
        else
        {
            playerAction.Subscribe();
        }
    }

    private void FixedUpdate()
    {
        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        rb.velocity = moveInput * currentSpeed;
    }

    
    private void LateUpdate()
    {
        UpdateIdleTimer();
        UpdateAnimations();
    }

    private void OnDisable()
    {
        DisableInput();
        moveAction.performed -= Move;
        moveAction.canceled -= Move;

        runAction.performed -= StartRunning;
        runAction.canceled -= StopRunning;

        interactAction.performed -= Interact;

        playerAction.Unsubscribe();
    }
    
    public void EnableInput()
    {
        inputActions.Enable();
    }

    public void DisableInput()
    {
        inputActions.Disable();
    }
    
    #endregion

    #region Movement
    private void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            idleTimer = 0f; // Reset idle timer when player moves
        }
    }

    private void StartRunning(InputAction.CallbackContext context)
    {
        isRunning = true;
    }

    private void StopRunning(InputAction.CallbackContext context)
    {
        isRunning = false;
    }
    #endregion

    #region Idle Timer
    private void UpdateIdleTimer()
    {
        if (moveInput == Vector2.zero)
        {
            idleTimer += Time.deltaTime;
        }
        else
        {
            ResetIdleTimer();
        }

        if (idleTimer >= idleTimeThreshold)
        {
            SetImpatientState(true);
        }
        else
        {
            SetImpatientState(false);
        }
    }

    public void ResetIdleTimer()
    {
        idleTimer = 0f;
    }

    private void SetImpatientState(bool isImpatient)
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("isImpatient", isImpatient);
        }
    }
    #endregion

    #region Animation
    public void UpdateAnimations()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            if (moveInput != Vector2.zero)
            {
                anim[i].SetFloat("dirX", moveInput.x);
                anim[i].SetFloat("dirY", moveInput.y);
                
                // Update the weapon animations in PlayerActions
                playerAction.dirX = moveInput.x;
                playerAction.dirY = moveInput.y;
            }

            anim[i].SetBool("isWalking", moveInput != Vector2.zero);
            anim[i].SetBool("isRunning", isRunning);
        }
    }
    #endregion

    #region Physics
    private void OnTriggerEnter2D(Collider2D other)
    {
        TrySelectInteractable(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        TryDeselectInteractable(other);
    }
    #endregion

    #region Interaction
    private void Interact(InputAction.CallbackContext ctx)
    {
        if (selectedInteractables.Count > 0)
        {
            selectedInteractables[0].Interact();
            StartCoroutine(CheckLastInteraction());
        }
    }

    IEnumerator CheckLastInteraction()
    {
        yield return null;
        if(selectedInteractables.Count > 0) 
            if (selectedInteractables[0] == null) 
            { 
                selectedInteractables.RemoveAt(0); 
            }
            
    }
    
    private void TrySelectInteractable(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable == null) { return; }
        selectedInteractables.Add(interactable);
        interactable.Select();
    }
    
    private void TryDeselectInteractable(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable == null) { return; }

        for (int i = 0; i < selectedInteractables.Count; i++)
        {
            if (interactable == selectedInteractables[i])
            {
                interactable.Deselect();
                selectedInteractables.RemoveAt(i);
            }
        }
    }
    #endregion
}
