using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField, Header("DialogueCanvas")] private GameObject sceneDialogue;
    private GameObject currentNPC;
    private Person person;
    [Header("TMP Text")]
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private TextMeshProUGUI npcDialogueIntro;
    [SerializeField] private TextMeshProUGUI npcDialogueSucces;

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
        person = npcData.GetComponent<Person>();

        //get the data to put on screen
        npcName.text = person.PersonName;
        npcDialogueIntro.text = person.PersonDialogueOnInteract;
        sceneDialogue.SetActive(true);

    }


}
