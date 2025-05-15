using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefabs; 

    public Transform[] spawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("CompleteLevel", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
