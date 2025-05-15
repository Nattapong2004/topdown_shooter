using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    private int hitCount = 0;
    public TextMeshProUGUI hitCountText;
    public GameObject panel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            hitCount++;
            if (hitCount >= 5)
            {
                Time.timeScale = 0;
                hitCountText.text = "You Loes!";
                panel.SetActive(true);
            }
        }
    }
}
