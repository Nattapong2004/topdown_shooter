using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1.5f; 
    [SerializeField] private float duration = 5f;         
    [SerializeField] private ParticleSystem pickupEffect; 
    [Header("Audio")]
    [SerializeField] private AudioClip pickupSound;     

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            PlayerController playerMovement = other.GetComponent<PlayerController>();
            if (playerMovement != null)
            {
                playerMovement.ApplySpeedBoost(speedMultiplier, duration);
            }

            Destroy(gameObject);
        }
    }
}
