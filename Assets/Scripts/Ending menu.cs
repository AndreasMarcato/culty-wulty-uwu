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
    private void Start()
    {
        END();
    }
    private IEnumerator Ending()
    {
      
        yield return new WaitForSeconds(8);
        canvasThingy.SetActive(true);
        
        

     }
}
