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
        LoadColor();
    }

    public Color TeamColor = Color.white;

    [System.Serializable]
    class SaveData
    {

    }

    public void SaveColor()
    {

    }

    public void LoadColor()
    {

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

    // ��Ǩ�ͺ��Ҵ�ҹ���Ŵ��͡�����������
    public static bool IsLevelUnlocked(int levelIndex)
    {
        // ��ҹ 1 �Ŵ��͡�� default
        if (levelIndex == 1) return true;

        return levelIndex <= GetHighestUnlockedLevel();
    }

    // �֧��Ҵ�ҹ�٧�ش���Ŵ��͡
    public static int GetHighestUnlockedLevel()
    {
        return PlayerPrefs.GetInt(UNLOCK_KEY, 1); // ���������鹤�ʹ�ҹ 1
    }

    // ����Ѻ��÷��ͺ (ź��ҷ��ѹ�֡���)
    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey(UNLOCK_KEY);
        PlayerPrefs.Save();
    }


}
