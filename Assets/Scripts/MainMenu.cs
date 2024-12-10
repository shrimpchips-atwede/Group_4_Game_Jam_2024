using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


    public Canvas mainMenu;
    public Canvas modeMenu;

    public Button startButton;
    public Button exitButton;
    public Button storyModeButton;
    public Button endlessModeButton;
    public Button backButton;
    public void Start()
    {
        modeMenu.enabled = false;
        startButton.interactable = false;
    }
    public void Update()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        if (gos.Length >= 2)
        {
            startButton.interactable = true;
        }
        //else if player wants to do 1p then do third menu"hey u sure u wnat to do 1p? yes no? sick man


    }
    public void Play()
    {

        mainMenu.enabled = false;
        modeMenu.enabled = true;

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StoryMode()
    {
        ScoreManager.instance.SetGameMode(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void EndlessMode()
    {

        ScoreManager.instance.SetGameMode(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Back()
    {
        modeMenu.enabled = false;
        mainMenu.enabled = true;

    }
}
