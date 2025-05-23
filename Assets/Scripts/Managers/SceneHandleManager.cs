using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandleManager : MonoBehaviour
{
    public static SceneHandleManager Instance { get; private set; }
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

    //Load and Unload Scenes
    public void LoadGameOverScene() => SceneManager.LoadSceneAsync(3);

    public void LoadWin() => SceneManager.LoadSceneAsync(1);

}
