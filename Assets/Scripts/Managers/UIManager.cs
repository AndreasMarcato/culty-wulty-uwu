using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField, Header("DialogueCanvas")] private GameObject sceneDialogue;
    private GameObject currentNPC;
    private int personHealthReference;
    private Person person;
    [Header("TMP Text")]
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private TextMeshProUGUI npcDialogueIntro;
    //[SerializeField] private TextMeshProUGUI npcDialogueSucces;



    //player stuff
    [SerializeField] private PersonDATA DATA_REFERENCE;
    [SerializeField] private GameObject ActionsPanelGO;
    [SerializeField] private TextMeshProUGUI option1;
    [SerializeField] private TextMeshProUGUI option2;
    [SerializeField] private TextMeshProUGUI option3;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            sceneDialogue.SetActive(false);
        }
    }


    public void SetUp(GameObject npcData, Person.PersonType type, int storedIndex)
    {
        //get basic stuff
        currentNPC = npcData;
        personHealthReference = npcData.GetComponent<Person>().PersonHealth;
        person = npcData.GetComponent<Person>();

        //get the data to put on screen
        npcName.text = person.PersonName;
        npcDialogueIntro.text = person.PersonDialogueOnInteract;
        SetUpActionOptions(type, storedIndex);
        sceneDialogue.SetActive(true);

    }

    public void HealthUpdate(int damage)
    {
        personHealthReference = personHealthReference - damage;
    }
    public void ShowActionPanel() => ActionsPanelGO.SetActive(true);
    public void HideActionPanel() => ActionsPanelGO.SetActive(false);
    public void SetUpActionOptions(Person.PersonType personType, int index)
    {
        string s1 = "0";
        string s2 = "0";
        
     
        switch (personType)
        {
            case Person.PersonType.SAD:
                //VS SAD PERSON ACTIONS
                s1 = DATA_REFERENCE.playerSadResponse[0];
                s2 = DATA_REFERENCE.playerNeutralResponse[Random.Range(0, DATA_REFERENCE.personNeutralDialogueOnInteractData.Length-1)];
                break;
            case Person.PersonType.NEUTRAL:
                //VS SAD NEUTRAL ACTIONS
                s1 = DATA_REFERENCE.playerNeutralResponse[0];
                s2 = DATA_REFERENCE.playerSadResponse[Random.Range(0, DATA_REFERENCE.personSadDialogueOnInteractData.Length-1)];
                break;
            case Person.PersonType.BOSS:
                //VS SAD BOSS ACTIONS
                s1 = DATA_REFERENCE.playerBossResponse[0];
                s2 = DATA_REFERENCE.playerNeutralResponse[Random.Range(0, DATA_REFERENCE.personNeutralDialogueOnInteractData.Length)];
                break;
        }
        RandomizerPosition(s1, s2);
    }

    private void RandomizerPosition(string s1, string s2)
    {
        int randomizerPosition = Random.Range(0, 2);
        if (randomizerPosition == 0)
        {
            option1.text = s1;
            option2.text = s2;
        }
        else
        {
            option1.text = s2;
            option2.text = s1;
        }
        
    }


}
