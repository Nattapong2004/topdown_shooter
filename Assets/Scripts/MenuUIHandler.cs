
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{

    public void StartNew()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
