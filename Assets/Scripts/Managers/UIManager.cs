using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField, Header("DialogueCanvas")] private GameObject sceneDialogue;
    [HideInInspector] public GameObject currentNPC;
    private int personHealthReference;
    private Person person;
    [Header("TMP Text")]
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private TextMeshProUGUI npcDialogueIntro;
    //[SerializeField] private TextMeshProUGUI npcDialogueSucces;

    Animator _playerAnimator;

    //player stuff
    [SerializeField] private PersonDATA DATA_REFERENCE;
    [SerializeField] private GameObject ActionsPanelGO;
    [SerializeField] private GameObject AnswerPanelGO;

    [SerializeField] public Button magicButton;

    [SerializeField] private TextMeshProUGUI option1;
    [SerializeField] private TextMeshProUGUI option2;
    [SerializeField] private TextMeshProUGUI option3;
    [SerializeField] private TextMeshProUGUI answerText;
    private string answerYesString;
    private string answerNoString;
    private string answerMagic;


    bool isBossMagic = false;

    private int goodPoint;
    bool hasWon = false;

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
    private void Start()
    {
        _playerAnimator = GameObject.FindGameObjectWithTag("PlayerVisual").GetComponent<Animator>();
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

        switch (type)
        {
            case (Person.PersonType.SAD):
                answerYesString = DATA_REFERENCE.personSadDialogueResponseYesData[Random.Range(0, DATA_REFERENCE.personSadDialogueResponseYesData.Length)];
                answerNoString = DATA_REFERENCE.personSadDialogueResponseNoData[Random.Range(0, DATA_REFERENCE.personSadDialogueResponseNoData.Length)];
                break;
            case (Person.PersonType.NEUTRAL):
                answerYesString = DATA_REFERENCE.personNeutralDialogueResponseYesData[Random.Range(0, DATA_REFERENCE.personNeutralDialogueResponseYesData.Length)];
                answerNoString = DATA_REFERENCE.personNeutralDialogueResponseNoData[Random.Range(0, DATA_REFERENCE.personNeutralDialogueResponseNoData.Length)];
                break;
            case (Person.PersonType.BOSS):
                currentNPC.GetComponentInChildren<NpcVisual>().BossInteract();
                answerYesString = DATA_REFERENCE.personBossDialogueResponseYesData[Random.Range(0, DATA_REFERENCE.personBossDialogueResponseYesData.Length)];
                answerNoString = DATA_REFERENCE.personBossDialogueResponseNoData[Random.Range(0, DATA_REFERENCE.personBossDialogueResponseNoData.Length)];
                break;
        }
        answerMagic = DATA_REFERENCE.playerMagicResponse[Random.Range(0, DATA_REFERENCE.playerMagicResponse.Length)];

    }

    public void HealthUpdate(int damage)
    {
        personHealthReference = personHealthReference - damage;
    }
    public void ShowActionPanel() => ActionsPanelGO.SetActive(true);
    public void ShowAnswerPanel(bool text)
    {
        AnswerPanelGO.SetActive(true);
    }
    public void HideActionPanel() => ActionsPanelGO.SetActive(false);
    public void HideAnswerPanel() => AnswerPanelGO.SetActive(false);
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
                s2 = DATA_REFERENCE.playerBossResponse[1];
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
            goodPoint = 0;
        }
        else
        {
            option1.text = s2;
            option2.text = s1;
            goodPoint = 1;
        }
        
    }

    public void CheckAnswer(bool isOption1)
    {
        hasWon = false;
        if (isOption1)
            if (goodPoint == 0)
                hasWon = true;
            else
                hasWon = false;
        else if (!isOption1)
            if (goodPoint == 1)
                hasWon = true;
            else
                hasWon = false;

        if (hasWon)
            answerText.text = answerYesString;
        else
            answerText.text = answerNoString;

        if (currentNPC.GetComponent<Person>().personType == Person.PersonType.BOSS)
        {
            hasWon = false;
            answerText.text = answerNoString;
            GameManager.Instance.failCount += 100;

        }

        ShowAnswerPanel(hasWon);
    }
    
    public void Magic()
    {
        isBossMagic = false;
        if (currentNPC.GetComponent<Person>().personType == Person.PersonType.BOSS)
        {
            isBossMagic = true;
        }
        _playerAnimator.SetTrigger("Magic");
        answerText.text = answerMagic;
        hasWon = true;
        if (currentNPC.GetComponent<Person>().personType == Person.PersonType.BOSS)
            GameManager.Instance.convertedPagans += 100;
        ShowAnswerPanel(hasWon);

    }

    public void EndDialogue() 
    {
        GameManager.Instance.WinCheck(hasWon);
        GameManager.Instance.SwapActionMap();
    }



    public void UpdateUI()
    {
        Debug.Log("BOB");
    }


}