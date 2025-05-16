using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    [SerializeField]  float speedMultiplier = 2;
    [SerializeField]  float duration = 1.5f;

    void OnTriggerEnter(Collider other)
    {
            var player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ApplySpeedBoost(speedMultiplier, duration);
                Destroy(gameObject);
            }
    }
}
