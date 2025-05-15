using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; // ���� Level �����������

    void Start()
    {
        // ��Ǩ�ͺ��� Player ������������˹
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        // ��駤�һ��������ѹ
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false; // ��͡ Level ����ѧ��������
            }
        }
    }

    public void SelectLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    // ���¡����ͨ� Level ���ͻŴ��͡ Level ����
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