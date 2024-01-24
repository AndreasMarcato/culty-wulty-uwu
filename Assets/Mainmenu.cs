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
        SceneManager.LoadScene(2);

    }

    public void LoadDreamPanel()
    {
        StartCoroutine(LoadDream());
    }
    private IEnumerator LoadDream()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }


    public void QuitGame()
    {
        Debug.Log("We quitty and hit the gritty");
        Application.Quit();
    }
}
