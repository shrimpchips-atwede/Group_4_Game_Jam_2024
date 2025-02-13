using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProfileUI : MonoBehaviour
{
    public string[] playerProfileColors = new string[] { "red", "blue", "orange", "green", "yellow", "purple", "white", "gray" };

    public TextMeshPro profileCursor;
    public TextMeshPro playerProfile;
    public TextMeshPro profileHat;
    public TextMeshPro profileMoney;
    public TextMeshPro profileLevels;
    public TextMeshPro profileWPM;
    public TextMeshPro profileEnter;
    public TextMeshPro profileDelete;
    public List<Transform> cursorTransforms;
    public int selectingWhat;

    public void Start()
    {
        cursorTransforms = new List<Transform>() { playerProfile.transform, profileHat.transform, profileEnter.transform, profileDelete.transform};

    }
    public void Update()
    {



    }
    public void Play()
    {



    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UpdatePlayerDataUI(int playerProfileNumber, int wagesCollected, float wpm, int levelsCompleted)//also pass in hat?
    {
        playerProfile.text = "Player Profile: " + playerProfileColors[playerProfileNumber];
        profileMoney.text =  "Collected Wages: " + wagesCollected;
        profileWPM.text = "WPM: " + wpm;
        profileLevels.text = "Level: " + levelsCompleted;

    }
    public void Back()
    {
        //move cursor

    }
}
