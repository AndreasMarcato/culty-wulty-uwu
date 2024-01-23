using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void PlayGame ()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));

    }
    IEnumerator LoadLevel (int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("DevIza-Scene");

    }

    public void QuitGame()
    {
        Debug.Log("We quitty and hit the gritty");
        Application.Quit();
    }
}
