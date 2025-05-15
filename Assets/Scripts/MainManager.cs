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

    // ตรวจสอบว่าด่านนี้ปลดล็อกแล้วหรือไม่
    public static bool IsLevelUnlocked(int levelIndex)
    {
        // ด่าน 1 ปลดล็อกโดย default
        if (levelIndex == 1) return true;

        return levelIndex <= GetHighestUnlockedLevel();
    }

    // ดึงค่าด่านสูงสุดที่ปลดล็อก
    public static int GetHighestUnlockedLevel()
    {
        return PlayerPrefs.GetInt(UNLOCK_KEY, 1); // ค่าเริ่มต้นคือด่าน 1
    }

    // สำหรับการทดสอบ (ลบค่าที่บันทึกไว้)
    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey(UNLOCK_KEY);
        PlayerPrefs.Save();
    }


}
