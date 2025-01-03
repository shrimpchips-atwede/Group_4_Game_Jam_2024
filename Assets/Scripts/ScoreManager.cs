using JetBrains.Annotations;
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
    public float wpmTimer = 0;
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
            //Destroy(go);

        }



        DontDestroyOnLoad(this);

    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))//just for playtesting/getting players unstuck
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");

            GameObject spawnPos = GameObject.FindGameObjectWithTag("SpawnPos");

            foreach (GameObject go in gos)
            {
                go.transform.position = spawnPos.transform.position;
            }
        }

    }
    public void EndGame()
    {
        MainComputerScreen.instance.isCounting = false;
        CalculateWPM(score);
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


        // return if not the start calling scene//no idea what this means
        if (!string.Equals(scene.path, this.scene.path))
        {
            return;
        }


        


    }
    public void WPMTimer()
    {
        wpmTimer += Time.deltaTime;
        Debug.Log(wpmTimer);
 
        //set variable to zero, start timer if bool is true
        //if bool is false, assign time to variable, stop timer
    }
    public void CalculateWPM(int score)
    {
        wpm = score/(wpmTimer / 60);
        wpmTimer = 0f;
        //ScoreManager.instance.wpm = ((maxTime - timerDuration) / 60) * score;
    }
}
