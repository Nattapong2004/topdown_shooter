using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; // ปุ่ม Level ทั้งหมดในเมนู

    void Start()
    {
        // ตรวจสอบว่า Player เคยเล่นมาไกลแค่ไหน
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        // ตั้งค่าปุ่มแต่ละอัน
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false; // ล็อก Level ที่ยังเล่นไม่ได้
            }
        }
    }

    public void SelectLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    // เรียกเมื่อจบ Level เพื่อปลดล็อก Level ต่อไป
    public static void CompleteLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", currentLevel + 1);
            PlayerPrefs.Save();
        }
    }
}