using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void StartNew()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SaveColorClicked()
    {
        Debug.Log(Application.persistentDataPath);
        string fileName = "save-data.txt";
        string filePath = Application.persistentDataPath + "/" + fileName;
        String content = "Hello World";
        File.WriteAllText(filePath, content);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
        

    public void LoadColorClicked()
    {

    }
}
