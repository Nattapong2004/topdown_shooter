using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionUI : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;
    //[SerializeField] private GameObject lockedIconPrefab;

    void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;

            if (!MainManager.IsLevelUnlocked(levelIndex))
            {
                // ´èÒ¹·ÕèÂÑ§äÁè»Å´ÅçÍ¡
                //Instantiate(lockedIconPrefab, levelButtons[i].transform);
                levelButtons[i].interactable = false;
                //levelButtons[i].GetComponentInChildren<TMP_Text>().text = "ÅçÍ¡ÍÂÙè";
            }
            else
            {
                // ´èÒ¹·Õè»Å´ÅçÍ¡áÅéÇ
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
