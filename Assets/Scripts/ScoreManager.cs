using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private Scene scene;
    public GameObject scoreManager;
    public int score;
    public float wpm;
    public float gameTimer = 5;
    public static ScoreManager instance;
    public int gameMode;
    public GameObject spawnPos;


    private void Awake()
    {
        // It is save to remove listeners even if they
        // didn't exist so far.
        // This makes sure it is added only once
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Add the listener to be called when a scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;

        DontDestroyOnLoad(gameObject);

        // Store the creating scene as the scene to trigger start
        scene = SceneManager.GetActiveScene();
    }
    void Start()
    {


        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in gos)
        {
            Destroy(go);

        }



        DontDestroyOnLoad(this);

    }

    public void EndGame()
    {
        MainComputerScreen.instance.CalculateWPM(score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SetGameMode(int i)
    {
        gameMode = i;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Debug.Log("Re-Initializing", this);
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");

        GameObject spawnPos = GameObject.FindGameObjectWithTag("SpawnPos");

        foreach (GameObject go in gos)
        {
            go.transform.position = spawnPos.transform.position;
        }


        // return if not the start calling scene
        if (!string.Equals(scene.path, this.scene.path))
        {
            return;
        }





    }
}
