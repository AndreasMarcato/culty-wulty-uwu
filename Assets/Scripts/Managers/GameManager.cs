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


    public void HandlePersonInteractionScene()
    {
        playerInput.actions.FindActionMap("PlayerInputOOC").Disable();
        playerInput.actions.FindActionMap("PlayerInputIC").Enable();

        SceneManager.LoadScene(_sceneDialogue.name, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(1, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        return;
    }


}
