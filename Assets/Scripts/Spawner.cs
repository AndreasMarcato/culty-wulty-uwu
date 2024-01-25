using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [Header("Lists of NPC Prefabs and Spawner Transforms")]
    [SerializeField] private List<GameObject> prefabsNPC = new List<GameObject>();
    [SerializeField] private List<Transform> prefabSpawnerPlace = new List<Transform>();
    [Space, Header("Values")]
    [SerializeField] private int maxNumberNPCOnScreen = 10;
    [SerializeField] public int currentNpcOnScreen = 0;
    [SerializeField] private float spawnIntervalCheck = 5;

    private void Start()
    {
        InvokeRepeating("SpawnNPC", 1, spawnIntervalCheck);
        //InvokeRepeating("SpawnItems", 1, 60);
    }
    private void SpawnNPC()
    {
        if (currentNpcOnScreen <= maxNumberNPCOnScreen)
        {
            GameObject randomNpcToSpawn = prefabsNPC[Random.Range(0, prefabsNPC.Count)];
            Transform randomSpawnerPlace = prefabSpawnerPlace[Random.Range(0, prefabSpawnerPlace.Count)];

            Instantiate(randomNpcToSpawn, randomSpawnerPlace.position, Quaternion.identity);
            currentNpcOnScreen++;
        }


    }

    //MAKE A COUNTER OF CONVERTED FOR THE ITEM



}
