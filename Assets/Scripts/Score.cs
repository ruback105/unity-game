using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    public float score;

    public Image progressBar;

    public AudioClip levelSong;

    public float onePercent = 0.1f;

    public void Start()
    {
        if(progressBar && levelSong)
        {
            onePercent = (float)(100 / levelSong.length / 100);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") + 1f * Time.deltaTime);
        scoreText.text = ((int)PlayerPrefs.GetFloat("score")).ToString();
        if(progressBar && (float)PlayerPrefs.GetFloat("level_progress") < 1)
        {
            PlayerPrefs.SetFloat("level_progress", PlayerPrefs.GetFloat("level_progress") + onePercent * Time.deltaTime);
            progressBar.rectTransform.localScale = new Vector3((float)PlayerPrefs.GetFloat("level_progress"), 1, 1);
        }
    }

    public void setScore(float difference)
    {
        PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") + difference);
    }
}
