using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    void Update()
    {
        // Ensure the object stays within the bounding box
        
    }
    public void OnTriggerEnter2D(Collider2D interactable)
    {
        if (interactable.GetComponent<Interactable>() != null)
        {
            GameManager.Instance._interactableList.Add(interactable);
            Debug.Log(interactable.name + "added");

        }
    }
    public void OnTriggerExit2D(Collider2D interactable)
    {
        if (interactable != null)
        {
            if (GameManager.Instance._interactableList.Contains(interactable))
                GameManager.Instance._interactableList.Remove(interactable);
            Debug.Log(interactable.name + "removed");
        }
    }

    

  

}
