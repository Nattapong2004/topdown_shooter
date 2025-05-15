using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawnManager : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;
    public GameObject panel;
    public TextMeshProUGUI hitCountText;

    private int currentWave = 0;
    private float waveEndTime = 0f;
   

    void Start()
    {
        waveController.StartWave(waveConfigurations[currentWave]);
        waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
        panel.SetActive(false); 
    }

    void Update()
    {
        if (currentWave >= waveConfigurations.Length)
            return;

        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            if (currentWave >= waveConfigurations.Length)
            {
               
                Invoke("CompleteLevel",10f);
            }

            else
            {
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }

        }

    }

        void CompleteLevel()
    { 
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        MainManager.UnlockNextLevel(currentLevelIndex);
        Time.timeScale = 0;
        hitCountText.text = "You Win!";
        panel.SetActive(true);
    }

    }
