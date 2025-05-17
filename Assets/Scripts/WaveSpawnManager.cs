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
    private bool checkingEnemies = false;


    void Start()
    {
        Time.timeScale = 1;
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
            if (!checkingEnemies)
            {
                checkingEnemies = true;
                InvokeRepeating("CheckEnemiesCleared", 0.5f, 0.5f); // ตรวจสอบทุก 0.5 วินาที
            }
            currentWave++;
            if (currentWave >= waveConfigurations.Length)
            {

                CompleteLevel();
            }

            else
            {
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }

        }

    }
    void CheckEnemiesCleared()
    {
        if (AreAllEnemiesDefeated())
        {
            CancelInvoke("CheckEnemiesCleared");
            checkingEnemies = false;

            currentWave++;
            if (currentWave >= waveConfigurations.Length)
            {
                CompleteLevel();
            }
            else
            {
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }
        }
    }
    bool AreAllEnemiesDefeated()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Animal");
        return enemies.Length == 0;
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
