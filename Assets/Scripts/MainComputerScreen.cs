using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainComputerScreen : MonoBehaviour
{
    //public List<string> sentences = new List<string>();
    //private int sentenceIndex = 0;

    //public string currentSentence = "Hello!";

    public string playerTypedSentence = string.Empty;

    public bool isShiftHeldDown = false;
    public bool isCapsLockOn = false;

    public TextMeshPro playerText;
    public static MainComputerScreen instance;
    public Assignments assignments;

    private bool isPlayer1Ready = false;
    private bool isPlayer2Ready = false;
    private bool hasGameStarted = false;

    public CinemachineVirtualCamera cam1;


    public float timerCounting = 0f;  //The current time on the timer;
    public float timerDuration = 300f;    //The time we need to wait before the timer finishes.
    public TextMeshPro timertext;

    public bool isCounting = false;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //currentSentence = sentences[0];
        //playerText.text = playerTypedSentence;
        Debug.Log(playerText.text);


    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    StartGame();
        //}

        if (isCounting == true)
        {
            timerDuration -= Time.deltaTime; //Timer increases by the time between frames (at a rate of 1 second per second)
            int minutes = Mathf.FloorToInt(timerDuration / 60);
            int seconds = Mathf.FloorToInt(timerDuration % 60);

            timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if (timerDuration <= 0f) //If the timer reaches above the timer duration...
        {
            EndGame();
            

        }

       
        

        //Debug.Log(timerCountingUp);
    }

    public void EndGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void CheckPlayerTextMainComputer()
    {
        assignments.CheckPlayerText();
    }
    public void AddKeyToSentence(char character)
    {
        if(playerTypedSentence.Length < 8)
        {
            if (isShiftHeldDown == true)
            {
                playerTypedSentence += char.ToUpper(character);

            }
            else
            {

                playerTypedSentence += character.ToString();
            }

            playerText.text = playerTypedSentence;
        }
        


    }

    public void PlayerReady(bool isPlayer1, bool isReady)
    {
        if (isPlayer1)
        {
            isPlayer1Ready = isReady;
            Debug.Log("p1 is ready: " + isReady);
        }
        else
        {
            isPlayer2Ready = isReady;
            Debug.Log("p2 is ready: " + isReady);
        }

        if(isPlayer1Ready && isPlayer2Ready && hasGameStarted == false)
        {
            hasGameStarted = true;//movecamera????
            StartGame();
        }
    }


    private void StartGame()
    {
        cam1.Priority = -10;
        isCounting = true;
        playerText.text = playerTypedSentence;
        assignments.StartFirstAssignment();
        //show text w timer when game starts.
    }

    public void PressBackspace()
    {
        if (playerTypedSentence.Length > 0)
        {
            Debug.Log("pressBackspace");
            Debug.Log(playerTypedSentence.Length);
            Debug.Log(playerTypedSentence.Substring(0, playerTypedSentence.Length - 1));
        

            playerTypedSentence =  playerTypedSentence.Substring(0, playerTypedSentence.Length - 1);
            playerText.text = playerTypedSentence;

        }

    }

    public void PressClear()
    {
        if (playerTypedSentence.Length > 0)
        {
            playerTypedSentence = string.Empty;
            playerText.text = playerTypedSentence;
            Debug.Log("clear");
        }
    }


}
