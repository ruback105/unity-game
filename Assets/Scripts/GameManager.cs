using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public void Start()
    {
        PlayerPrefs.SetInt("game_ended", 0);
        PlayerPrefs.SetFloat("level_progress", 0);
        PlayerPrefs.SetFloat("score", 0);
    }

    public void CompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame ()
    {
        if(PlayerPrefs.GetInt("game_ended") == 0)
        {
            PlayerPrefs.SetInt("game_ended", 1);
            if (PlayerPrefs.GetInt("HighScore") < (int)PlayerPrefs.GetFloat("score"))
            {
                PlayerPrefs.SetInt("HighScore", (int)PlayerPrefs.GetFloat("score"));
            }
            Invoke("Restart", restartDelay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
