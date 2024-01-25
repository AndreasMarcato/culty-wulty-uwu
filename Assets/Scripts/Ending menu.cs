using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endingmenu : MonoBehaviour
{

    CanvasGroup canvasGroup;
    public void END()
    {
        StartCoroutine(Ending());
    }
 
    private IEnumerator Ending()
    {
      
        yield return new WaitForSeconds(2);
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        
        

     }
}
