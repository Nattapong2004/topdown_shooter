using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public void Next()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}
