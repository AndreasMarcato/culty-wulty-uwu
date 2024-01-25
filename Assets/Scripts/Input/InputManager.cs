using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput _playerInput;
    private Transform _playerTransform;
    private PlayerVisual _playerVisual;

    
    // Game Input
    private InputAction moveAction;
    private Vector2 move;
    private Vector2 inputEvent;
    [SerializeField] private float playerVelocity;

    private InputAction interactTapAction;
    private InputAction interactHoldAction;

    //limit area of movement
    private BoxCollider2D boundingBox;
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
        _playerVisual = _playerTransform.GetComponentInChildren<PlayerVisual>();
        
        // Get the BoxCollider2D component attached to this game object
        boundingBox = GameObject.FindGameObjectWithTag("BoundingBox").GetComponent<BoxCollider2D>();
        if (boundingBox == null)
            Debug.LogError("BoxCollider2D not found on this game object!");
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

        ClampToBounds();

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
         _playerVisual.StartWalking();
        if (inputEvent.x > 0)
        {
            _playerVisual.transform.localScale = new Vector3(Mathf.Abs(_playerVisual.transform.localScale.x), _playerVisual.transform.localScale.y, _playerVisual.transform.localScale.z);
        }
        else
        {
            _playerVisual.transform.localScale = new Vector3(-Mathf.Abs(_playerVisual.transform.localScale.x), _playerVisual.transform.localScale.y, _playerVisual.transform.localScale.z);
        }


    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        Debug.Log("Move Canceled");
        inputEvent = Vector2.zero;
        _playerVisual.StopWalking();

    }

    private void OnInteractTapPerformed(InputAction.CallbackContext obj)
    {
        
        if (GameManager.Instance._interactableList.Count > 0)
        {
            GameManager.Instance._interactableList[0].GetComponent<Interactable>().Interact();
            Transform tra = GameManager.Instance._interactableList[0].transform;
            if (tra.position.x < _playerTransform.position.x)
                tra.transform.localScale = new Vector3(-Mathf.Abs(tra.transform.localScale.x), tra.transform.localScale.y, tra.transform.localScale.z);
            else
                tra.transform.localScale = new Vector3(Mathf.Abs(tra.transform.localScale.x), tra.transform.localScale.y, tra.transform.localScale.z);
        }
        Debug.Log("Interact Tap Performed");
    }

    private void OnInteractHoldPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Interact Hold Performed");
    }

    void ClampToBounds()
    {
        if (boundingBox != null)
        {
            // Get the position of the game object
            Vector3 newPosition = _playerTransform.position;

            // Calculate the bounds of the box collider
            float minX = boundingBox.bounds.min.x;
            float maxX = boundingBox.bounds.max.x;
            float minY = boundingBox.bounds.min.y;
            float maxY = boundingBox.bounds.max.y;

            // Clamp the position to stay within the bounding box
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            // Update the position of the game object
            _playerTransform.position = newPosition;
        }
    }
}