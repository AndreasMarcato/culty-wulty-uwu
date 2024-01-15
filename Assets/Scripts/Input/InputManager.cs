using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput _playerInput;
    private Transform _playerTransform;
    
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

        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        if (_playerTransform != null )
        {
            _playerTransform.Translate((move * playerVelocity) * Time.deltaTime);
        }
        else
            _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();



    }

    #region Event Subscription
    
    private void OnEnable()
    {
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;
        
        interactTapAction.performed += OnInteractTapPerformed;
        interactHoldAction.performed += OnInteractHoldPerformed;


    }

    private void OnDisable()
    {
        moveAction.performed -= OnMovePerformed;
        moveAction.canceled -= OnMoveCanceled;

        interactTapAction.performed -= OnInteractTapPerformed;
        interactHoldAction.performed -= OnInteractHoldPerformed;
    }

    #endregion
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

    private void OnInteractTapPerformed(InputAction.CallbackContext obj)
    {
        
        if (GameManager.Instance._interactableList.Count > 0)
        {
            GameManager.Instance._interactableList[0].GetComponent<Interactable>().Interact();
        }
        Debug.Log("Interact Tap Performed");
    }

    private void OnInteractHoldPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Interact Hold Performed");
    }

    
}