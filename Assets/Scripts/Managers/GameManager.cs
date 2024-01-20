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
    private List<GameObject> inventory { get;  set; } = new List<GameObject>();
    public List<GameObject> Inventory => inventory;
    

    public SceneAsset _sceneDialogue;

    [SerializeField] private PlayerInput playerInput;

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
        playerInput = GameObject.FindFirstObjectByType<PlayerInput>();
    }


    public void HandlePersonInteractionScene(GameObject obj)
    {
        obj.GetComponent<NpcLogic>().isTalkking = true;
        SwapActionMap();

        SceneManager.LoadScene(_sceneDialogue.name, LoadSceneMode.Additive);
        //Scene active = SceneManager.GetActiveScene();
        //SceneManager.UnloadSceneAsync(active, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        return;
    }

    private void SwapActionMap()
    {
        if (playerInput.actions.FindActionMap("PlayerInputOOC").enabled)
        {
            playerInput.actions.FindActionMap("PlayerInputOOC").Disable();
            playerInput.actions.FindActionMap("PlayerInputIC").Enable();
        }
        else
        {
            playerInput.actions.FindActionMap("PlayerInputOOC").Enable();
            playerInput.actions.FindActionMap("PlayerInputIC").Disable();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            inventory.RemoveAt(0);
        if (Input.GetKeyDown(KeyCode.H))
            Instantiate(inventory[1]);

        Debug.Log(inventory.Count);
    }
}
