using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endingmenu : MonoBehaviour
{
    [SerializeField] private GameObject canvasThingy;
    public void END()
    {
        StartCoroutine(Ending());
    }
 
    private IEnumerator Ending()
    {
      
        yield return new WaitForSeconds(3);
        canvasThingy.SetActive(true);
        
        

     }
}
