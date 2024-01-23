using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    //get the data manually by dragging and dropping the SO Asset in here
    [SerializeField] private PersonDATA personDATA;

    private string personName;
    private string personDialogueOnInteract;
    private string personDialogueResponseNo;
    private string personDialogueResponseYes;
    private int personHealth;


    //property to be accessed from the UIManager
    public string PersonName => personName;
    public string PersonDialogueOnInteract => personDialogueOnInteract;
    public string PersonDialogueResponseNo => personDialogueResponseNo;
    public string PersonDialogueResponseYes => personDialogueResponseYes;
    public int PersonHealth => personHealth;

    
    public enum PersonType
    {
        SAD,
        NEUTRAL,
        BOSS
    }
    public PersonType personType;

    private void Awake()
    {
        personName = personDATA.personNameData[Random.Range(0, personDATA.personNameData.Length)];
        personDialogueOnInteract = GetDialogue();
    }

    private string GetDialogue()
    {
        int indexRandom;

        switch (personType)
        {
            case PersonType.SAD:
                indexRandom = Random.Range(0, personDATA.personSadDialogueOnInteractData.Length);
                personDialogueOnInteract = personDATA.personSadDialogueOnInteractData[indexRandom];
                UIManager.Instance.SetUpActionOptions(personType, indexRandom);
                break;
            case PersonType.NEUTRAL:
                indexRandom = Random.Range(0, personDATA.personNeutralDialogueOnInteractData.Length);
                personDialogueOnInteract = personDATA.personNeutralDialogueOnInteractData[indexRandom];
                break;
            case PersonType.BOSS:
                indexRandom = Random.Range(0, personDATA.personBossDialogueOnInteractData.Length);
                personDialogueOnInteract = personDATA.personBossDialogueOnInteractData[indexRandom];
                break;
        }
        return personDialogueOnInteract;
    }
}
