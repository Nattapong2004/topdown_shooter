using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefabs; 
    public Transform[] spawnPoints;

    
    void Start()
    {
        InvokeRepeating("Spawn", 2f,5f);
    }

    void Spawn()
    {
        int spawnIdx = Random.Range(0, spawnPoints.Length);
        int itemIdx = Random.Range(0, itemPrefabs.Length);

        Instantiate(itemPrefabs[itemIdx], spawnPoints[spawnIdx].position, Quaternion.identity);
    }
}
