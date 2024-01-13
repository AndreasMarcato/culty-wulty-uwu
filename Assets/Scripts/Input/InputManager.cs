using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput _playerInput;
    private CharacterController _characterController;
    
    // Game Input
    private InputAction moveAction;
    private Vector2 move;
    private Vector2 inputEvent;
    [SerializeField] private float playerVelocity;

    private InputAction interactTapAction;
    private InputAction interactHoldAction;

    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        
        _playerInput = GetComponent<PlayerInput>();
        moveAction = _playerInput.actions["Move"];
        interactTapAction = _playerInput.actions["InteractTap"];
        interactHoldAction = _playerInput.actions["InteractHold"];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
       
        move = new Vector2 (inputEvent.x, 0f).normalized;
        if (_characterController != null )
        {
            _characterController.Move((move * playerVelocity) * Time.deltaTime);
        }
        else
            _characterController = GameObject.FindFirstObjectByType<CharacterController>();



    }

    #region Event Subscription
    private void OnEnable()
    {
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;
        
        interactTapAction.performed += OnInteractTapPerformed;
        interactHoldAction.performed += OnInteractHoldPerformed;
    }
    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Move Performed");
        inputEvent = moveAction.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        Debug.Log("Move Canceled");
        inputEvent = Vector2.zero;
    }


    private void OnInteractHoldPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Interact Hold Performed");
    }

    private void OnInteractTapPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Interact Tap Performed");
    }

    private void OnDisable()
    {
        moveAction.performed -= OnMovePerformed;
        moveAction.canceled -= OnMoveCanceled;

        interactTapAction.performed -= OnInteractTapPerformed;
        interactHoldAction.performed -= OnInteractHoldPerformed;
    }
    #endregion
}
