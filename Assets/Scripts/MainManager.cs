using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    private const string UNLOCK_KEY = "UnlockedLevels";

    private static MainManager instance;
    public static MainManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public static void UnlockNextLevel(int currentLevelIndex)
    {
        
        int nextLevel = currentLevelIndex + 1;

        
        if (nextLevel > GetHighestUnlockedLevel())
        {
            PlayerPrefs.SetInt(UNLOCK_KEY, nextLevel);
            PlayerPrefs.Save();
        }
    }

    public static bool IsLevelUnlocked(int levelIndex)
    {
        
        if (levelIndex == 1) return true;

        return levelIndex <= GetHighestUnlockedLevel();
    }

    
    public static int GetHighestUnlockedLevel()
    {
        return PlayerPrefs.GetInt(UNLOCK_KEY, 1); 
    }

    
    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey(UNLOCK_KEY);
        PlayerPrefs.Save();
    }


}
