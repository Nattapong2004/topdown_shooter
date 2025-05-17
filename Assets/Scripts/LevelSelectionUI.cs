
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionUI : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;
    

    void Start()
    {
        Time.timeScale = 1;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;

            if (!MainManager.IsLevelUnlocked(levelIndex))
            {
                
                levelButtons[i].interactable = false;
                
            }
            else
            {
                levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
  
            }
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Main");
    }

    public void Next()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    
}
