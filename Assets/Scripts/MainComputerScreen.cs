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


    public int endlessAssignmentCounter = 0;
    public int endlessAssignmentCounterMax = 6;
    public float timerDuration = 300f;
    public float storyTimerDuration = 300f;
    public float endlessTimerDuration = 30f;

    public TextMeshPro timerText;
    public TextMeshPro endlessCounterQueueText;

    public bool isCounting = false;

    public int maxedTypedSentLength = 46;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        ////DELETE THIS IF BUILDING GAME LOL
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    StartGame();
        //}

        //Timer();
    }
    public void CheckPlayerTextMainComputer()
    {

        assignments.CheckPlayerText();

        if(ScoreManager.instance.gameMode == 1)
        {
            endlessCounterQueueText.text = endlessAssignmentCounter.ToString();
            if (endlessAssignmentCounter <= (endlessAssignmentCounterMax - 1))
            {
                endlessCounterQueueText.color = Color.white;
            }
        }

    }
    public void AddKeyToSentence(char character)
    {
        if(playerTypedSentence.Length < maxedTypedSentLength)
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
        //if scoremanager game mode is set to 0, then

        isCounting = true;
        if(ScoreManager.instance.gameMode == 1)
        {
            timerDuration = endlessTimerDuration;
        }
        else if (ScoreManager.instance.gameMode == 0)
        {
            timerDuration = storyTimerDuration;
        }
        //this is really dumb. make an enum in scoremanager???

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

    public void PressFear()
    {


        if(playerTypedSentence != "fear")
        {
            playerTypedSentence = "fear";
        }

        else if(playerTypedSentence == "fear")
        {
            playerTypedSentence = string.Empty;
        }
        playerText.text = playerTypedSentence;
        
    }

    public void CalculateWPM(int score)
    {
        //ScoreManager.instance.wpm = ((maxTime - timerDuration) / 60) * score;
    }

    public void Timer()
    {
        if (isCounting == true)
        {
            timerDuration -= Time.deltaTime; //Timer increases by the time between frames (at a rate of 1 second per second)

                int minutes = Mathf.FloorToInt(timerDuration / 60);
                int seconds = Mathf.FloorToInt(timerDuration % 60);

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            


        }

        if (timerDuration <= 0f)
        {
            if(ScoreManager.instance.gameMode == 0)
            {
                ScoreManager.instance.EndGame();
            }

            else if (ScoreManager.instance.gameMode == 1)
            {
                if(endlessAssignmentCounter < endlessAssignmentCounterMax)
                {
                    timerDuration = endlessTimerDuration;
                    endlessAssignmentCounter++;
                    endlessCounterQueueText.text = endlessAssignmentCounter.ToString();


                    if (endlessAssignmentCounter >= (endlessAssignmentCounterMax - 1))
                    {
                        endlessCounterQueueText.color = Color.red;
                    }


                }

                else if (endlessAssignmentCounter == endlessAssignmentCounterMax)
                {
                    ScoreManager.instance.EndGame();
                }

            }


        }
    }
    public void EndlessTimerCompleteAssignment()
    {
        endlessAssignmentCounter--;
        endlessCounterQueueText.text = endlessAssignmentCounter.ToString();
    }

}
