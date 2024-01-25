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
                GameManager.Instance.inventory.Add(gameObject);
                gameObject.SetActive(false);
                return;
            case InteractableType.PERSON:

                if (GameManager.Instance.inventory.Count == 0)
                    UIManager.Instance.magicButton.interactable = false;
                else
                    UIManager.Instance.magicButton.interactable = true;

                GameManager.Instance.HandlePersonInteractionScene(gameObject);
                Person reference = this.gameObject.GetComponent<Person>();
                UIManager.Instance.SetUp(this.gameObject, reference.personType, reference.StoredIndex);
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


}
