using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreManager;
    public int score;
    public float wpm;
    public float gameTimer = 5;
    //
    // Start is called before the first frame update
    void Start()
    {
        //scoreManager = FindFirstObjectByType<ScoreManager>();
        //Destroy(scoreManager);//cant remember if this is how youre supposed to do this lol

        DontDestroyOnLoad(this);
    }

    public void EndGame()
    {
        float sc = score;
        sc /= gameTimer = wpm;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
