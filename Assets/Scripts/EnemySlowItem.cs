using UnityEngine;

public class EnemySlowItem : MonoBehaviour
{
    [SerializeField] private float slowMultiplier = 0.5f; 
    [SerializeField] private float duration = 5f; 
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            ApplySlowToAllEnemies();
            Destroy(gameObject);
        }
       
    }

    private void ApplySlowToAllEnemies()
    {
        MoveForwardDog[] allEnemies = FindObjectsOfType<MoveForwardDog>();
        foreach (MoveForwardDog enemy in allEnemies)
        {
            enemy.ApplySlow(slowMultiplier, duration);
        }
    }
}

