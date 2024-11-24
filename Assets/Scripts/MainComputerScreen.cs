using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //currentSentence = sentences[0];
        playerText.text = playerTypedSentence;
        Debug.Log(playerText.text);
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckPlayerTextMainComputer()
    {
        assignments.CheckPlayerText();
    }
    public void AddKeyToSentence(char character)
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

    public void PlayerReady(bool isPlayer1, bool isReady)
    {
        if (isPlayer1)
        {
            isPlayer1Ready = isReady;
        }
        else
        {
            isPlayer2Ready = isReady;
        }

        if(isPlayer1Ready && isPlayer2Ready && hasGameStarted == false)
        {
            hasGameStarted = true;
            StartGame();
        }
    }


    private void StartGame()
    {
        assignments.StartFirstAssignment();
        //Do Whatever you want to do one time when you start the game
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
            Debug.Log("why");
        }
    }


}
