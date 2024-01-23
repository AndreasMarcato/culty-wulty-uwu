using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Person DATA", menuName = "Assets/SO/Person")]
public class PersonDATA : ScriptableObject
{
    //Person Interactable
    public string[] personNameData;

    public string[] personSadDialogueOnInteractData;
    public string[] personSadDialogueResponseYesData;
    public string[] personSadDialogueResponseNoData;

    public string[] personNeutralDialogueOnInteractData;
    public string[] personNeutralDialogueResponseYesData;
    public string[] personNeutralDialogueResponseNoData;

    public string[] personBossDialogueOnInteractData;
    public string[] personBossDialogueResponseYesData;
    public string[] personBossDialogueResponseNoData;

    public string[] personDialogueFailData;
    public string[] personDialogueSucceedData;


    public int[] personHealthData;

    //Player Dialogues
    public string[] playerSadResponse;
    public string[] playerNeutralResponse;
    public string[] playerBossResponse;

    public string[] playerMagicResponse;

}
