using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Interactible trackers
    public List<Collider2D> _interactableList;

    //Player Inventory
    [HideInInspector] public List<GameObject> inventory = new List<GameObject>();

    [SerializeField] private PlayerInput _playerInput;


    //"in combat" stuff
    NpcLogic npcLogic;

    //player fail condition
    [HideInInspector] public int maxFailCount = 5;
    private int failCount;
    public int FailCount => failCount;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //get player input reference
        _playerInput = GameObject.FindFirstObjectByType<PlayerInput>();
    }

    private void Update()
    {
        Debug.Log(inventory.Count);

        //Check Loss Condition
        if (failCount == 5)
            StartLosingState();

    }

    private void StartLosingState()
    {
        //losing state
    }


    public void HandlePersonInteractionScene(GameObject npcReference)
    {
        //reference and boolean change
        npcLogic = npcReference.GetComponent<NpcLogic>();
        npcLogic.isTalking = true;

        //disable action map for input
        SwapActionMap();

        //Scene active = SceneManager.GetActiveScene();
        //SceneManager.UnloadSceneAsync(active, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        return;
    }
 

    public void SwapActionMap()
    {
        if (_playerInput.actions.FindActionMap("PlayerInputOOC").enabled)
        {
            _playerInput.actions.FindActionMap("PlayerInputOOC").Disable();
            _playerInput.actions.FindActionMap("PlayerInputIC").Enable();
        }
        else
        {
            _playerInput.actions.FindActionMap("PlayerInputOOC").Enable();
            _playerInput.actions.FindActionMap("PlayerInputIC").Disable();
        }
    }

    public void WinCheck(bool isRightAnswer)
    {
        npcLogic.KillNPC();
        if (!isRightAnswer)
        {
            failCount++;
            GameOverCheckAndStart();
        }
    }


    public void GameOverCheckAndStart()
    {
        if (failCount >= maxFailCount)
        {
            Debug.Log("GameOver");
            Spawner.Instance.currentNpcOnScreen = 0;
            inventory.Clear();
            SceneHandleManager.Instance.LoadGameOverScene();
        }
    }

}
