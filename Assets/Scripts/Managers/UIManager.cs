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


    public void SetUp(GameObject npcData)
    {
        //get basic stuff
        currentNPC = npcData;
        personHealthReference = npcData.GetComponent<Person>().PersonHealth;
        person = npcData.GetComponent<Person>();

        //get the data to put on screen
        npcName.text = person.PersonName;
        npcDialogueIntro.text = person.PersonDialogueOnInteract;
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

        switch(personType)
        {
            case Person.PersonType.SAD:
                //VS SAD PERSON ACTIONS
                switch (index)
                {
                    case 0:
                        string s1 = DATA_REFERENCE.playerSadResponse[0];
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                break;
            case Person.PersonType.NEUTRAL:
                //VS SAD NEUTRAL ACTIONS
                break;
            case Person.PersonType.BOSS:
                //VS SAD BOSS ACTIONS
                break;
        }
    }

    private void RandomizerPosition()
    {
        int randomizerPosition = Random.Range(0, 2);

    }


}
