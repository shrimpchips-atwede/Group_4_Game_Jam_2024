using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreManager;
    public int score;
    public float wpm;
    public float gameTimer = 5;
    public static ScoreManager instance;
    //
    // Start is called before the first frame update
    void Start()
    {
        //scoreManager = FindFirstObjectByType<ScoreManager>();
        //Destroy(scoreManager);//cant remember if this is how youre supposed to do this lol
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void EndGame()
    {
        MainComputerScreen.instance.CalculateWPM(score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
