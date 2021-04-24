using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    public void LoadNextLevel ()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
