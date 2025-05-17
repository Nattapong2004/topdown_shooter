
using UnityEngine;
using System.Collections.Generic;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private Queue<int> spawnQueue = new Queue<int>();
    private float spawnTimer = 0f;
    private const float SPAWN_INTERVAL = 5f;

    void Start()
    {
        InitializeSpawnQueue();
        PrewarmSpawn(); 
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= SPAWN_INTERVAL)
        {
            spawnTimer = 0f;
            SpawnItem();
        }
    }

    void InitializeSpawnQueue()
    {
        int[] indices = new int[spawnPoints.Length];
        for (int i = 0; i < indices.Length; i++)
        {
            indices[i] = i;
        }

        for (int i = indices.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (indices[i], indices[j]) = (indices[j], indices[i]);
        }

       
        spawnQueue.Clear();
        foreach (int index in indices)
        {
            spawnQueue.Enqueue(index);
        }
    }

    void PrewarmSpawn()
    {
        SpawnItem();
        spawnTimer = SPAWN_INTERVAL - 2f; 
    }

    void SpawnItem()
    {
        if (spawnQueue.Count == 0)
        {
            InitializeSpawnQueue(); 
        }

        int spawnIdx = spawnQueue.Dequeue();
        int itemIdx = Random.Range(0, itemPrefabs.Length);

        Instantiate(itemPrefabs[itemIdx], spawnPoints[spawnIdx].position, Quaternion.identity);
    }
}

