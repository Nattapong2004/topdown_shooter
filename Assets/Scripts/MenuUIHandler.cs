using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    //public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
    }

    private void Start()
    {
        //ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        //ColorPicker.onColorChanged += NewColorSelected;
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
