using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] GameObject dreamPanel;

    public void PlayGame ()
    {
        Debug.Log("playtime");
        SceneManager.LoadScene(0);

    }

    public void LoadDreamPanel()
    {
        StartCoroutine(LoadDream());
    }
    private IEnumerator LoadDream()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }


    public void QuitGame()
    {
        Debug.Log("We quitty and hit the gritty");
        Application.Quit();
    }
}
