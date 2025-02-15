using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProfileUI : MonoBehaviour
{
    //public string[] playerProfileColors = new string[] { "red", "blue", "orange", "yellow", "green", "purple", "white", "gray" };

    public GameObject profileCursor;
    public TextMeshPro playerProfile;
    public TextMeshPro profileHat;
    public TextMeshPro profileMoney;
    public TextMeshPro profileLevels;
    public TextMeshPro profileWPM;
    public TextMeshPro profileEnter;
    public TextMeshPro profileDelete;
    public List<GameObject> cursorTransforms;
    public int cursorSelection;



    public void Start()
    {
        cursorSelection = cursorTransforms.Count-1;
        MoveCursor();

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

    public void UpdatePlayerDataUI(PlayerData playerData)//also pass in hat?
    {
        profileCursor.transform.position = cursorTransforms[cursorSelection].transform.position;
        switch (cursorSelection)
        {
            
            case 3:
                playerProfile.text = "Player Profile: " + PlayerProfiles.instance.playerMaterials[playerData.playerProfileNumber].name;
                profileMoney.text = "Collected Wages: " + playerData.wagesCollected;
                profileWPM.text = "WPM: " + playerData.wpm;
                profileLevels.text = "Level: " + playerData.levelsCompleted;
                if(!playerData.isInitialized)
                {
                    profileDelete.text = "";
                }
                break;
            case 2:

                profileHat.text = "yay hat";// grab name of hat from hat dictionary?

                break;
            case 1:
                if (playerData.playerNumber == 0 && PlayerProfiles.instance.player1Ready || playerData.playerNumber == 1 && PlayerProfiles.instance.player2Ready)
                {
                    profileEnter.text = "player profile confirmed";
                }
                else
                {
                    profileEnter.text = "player profile not confirmed";
                }

                break;
            case 0:
                if (playerData.deleteData == false )
                {

                    profileDelete.text = "Delete :(";
                }
                else
                {
                    profileDelete.text = "Are you sure? this is undoeable";
                }

                break;

        }


    }
    public void ResetProfileUI()
    {
        profileDelete.text = "Are you sure? this is undoeable";
    }
    public void MoveCursor()
    {
        profileCursor.transform.position = cursorTransforms[cursorSelection].transform.position;
        Debug.Log("profile cursor moved to " +  cursorSelection + "th position");

    }
}
