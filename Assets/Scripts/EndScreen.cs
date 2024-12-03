using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndScreen : MonoBehaviour
{
    public Sprite goodBG;
    public Sprite badBG;
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI wpmText;

    public int score;


    public GameObject BG;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        score = scoreManager.score;

        scoreText.text = score.ToString();
        if (scoreManager.score <= 2)
        {
            BG.GetComponent<Image>().sprite = badBG;
        }
        else
        {
            BG.GetComponent<Image>().sprite = goodBG;
        }

        wpmText.text = "WPM: " + scoreManager.wpm.ToString();
    }
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
