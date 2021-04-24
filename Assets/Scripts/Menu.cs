using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private string infiniteLevel = "Scenes/Infinite";
    private string creditsLevel = "Scenes/Credits";

    public GameObject levels;

    public GameObject mainMenu;

    public void OpenLevels ()
    {
        levels.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void StartLevel ()
    {
        SceneManager.LoadScene("Scenes/" + gameObject.name);
    }

    public void StartInfinite ()
    {
        ClearScore();
        SceneManager.LoadScene(infiniteLevel);
    }

    public void StartCredits()
    {
        SceneManager.LoadScene(creditsLevel);
    }

    public void ClearScore ()
    {
        PlayerPrefs.SetFloat("score", 0);
    }

    public void Back ()
    {
        levels.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
