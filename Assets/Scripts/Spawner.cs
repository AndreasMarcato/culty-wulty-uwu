using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int maxNumberNPCOnScreen = 4;

    [SerializeField] private List<Transform> prefabSpawnerPlace = new List<Transform>();
    [SerializeField] private List<GameObject> prefabsNPC = new List<GameObject>();



    private void SpawnNPC()
    {
        int npcToSpawn = Random.Range(0, prefabsNPC.Count);
        int placeToSpawn = Random.Range(0, prefabSpawnerPlace.Count);
        Instantiate(prefabsNPC[npcToSpawn], prefabSpawnerPlace[placeToSpawn].position, Quaternion.identity);
    }





}
