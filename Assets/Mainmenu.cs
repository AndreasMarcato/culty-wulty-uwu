using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] GameObject dreamPanel;

    public void PlayGame ()
    {
        Debug.Log("playtime");
        SceneManager.LoadScene(2);

    }
=======
    public Animator transition;
    public float transitionTime = 2f;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    IEnumerator PlayGame ()
    {
        transition.SetTrigger("Start");
        yield return new WaitForEndOfFrame();
        Debug.Log("playtime");
        SceneManager.LoadScene(3);

    }

>>>>>>> Stashed changes

    public void LoadDreamPanel()
    {
        StartCoroutine(LoadDream());
    }
    private IEnumerator LoadDream()
    {
        yield return new WaitForSeconds(3);
        dreamPanel.SetActive(true);
    }


    public void QuitGame()
    {
        Debug.Log("We quitty and hit the gritty");
        Application.Quit();
    }
}
