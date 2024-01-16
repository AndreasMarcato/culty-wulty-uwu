using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IEInteractable
{
    public string interactibleName;
    public string interactibleDescription;
    public enum ObjectType
    {
        Fire,
        Ice,
        Light,
        Dark
    }
    public ObjectType CurrentType;


    public enum InteractableType
    {
        OBJECT,
        PERSON
    }
    public InteractableType type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Interact()
    {
        switch (type)
        {
            case InteractableType.OBJECT:
                Debug.Log("Object type");
                GameManager.Instance.Inventory.Add(gameObject);
                gameObject.SetActive(false);
                Invoke("Reposition", 60f);
                return;
            case InteractableType.PERSON:
                GameManager.Instance.HandlePersonInteractionScene();
                Debug.Log("Person type");
                return;
        }

        Debug.Log("Interated with " + gameObject.name);
    }


    private void ObjectInteraction(ObjectType t)
    {
        switch (t)
        {
            case ObjectType.Fire:
                {
                    //DoFireStuff
                }
                break;
            case ObjectType.Ice:
                {
                    //DoIceStuff
                }

            return;

        }
        return;
    }

    private void Reposition()
    {
        transform.position = new Vector3(Random.Range(-30, 30), transform.position.y, transform.position.z);
        gameObject.SetActive(true);
    }

}
