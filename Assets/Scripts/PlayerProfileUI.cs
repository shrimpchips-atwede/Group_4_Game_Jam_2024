using System;
using System.Collections.Generic;
using AASave;
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
    public GameObject player;
    public int charSelectPlayer;




    public void Start()
    {
        cursorSelection = cursorTransforms.Count-1;
        profileCursor.transform.position = cursorTransforms[cursorSelection].transform.position;



    }
    public void Update()
    {
        if (player == null)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < players.Length; i++)
            {

                if (players[i].GetComponent<PlayerData>().playerNumber == charSelectPlayer)
                {
                    player = players[i];

                    ChangePlayerProfileUI(player.GetComponent<PlayerData>());//need to do a stupid event. this is being done wrong
                    break;

                }

            }


        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateProfileMenuUI(PlayerData playerData)//also pass in hat?
    {



        switch (cursorSelection)
        {
            
            case 3:
                ChangePlayerProfileUI(playerData);
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
                if (playerData.deleteData <= 1 )
                {
                    profileDelete.text = "Are you sure? this is undoeable";
                }
                else if (playerData.deleteData == 2)
                {
                    ChangePlayerProfileUI(playerData);

                }

                break;

        }


    }
    public void ResetProfileUI()
    {
        profileDelete.text = "Are you sure? this is undoeable";
    }
    public void MoveCursor(PlayerData playerData)
    {
        if (!playerData.isInitialized)
        {
            if (cursorSelection == 0 || cursorSelection > 3)
            {
                cursorSelection = 3;

            }
        }

        profileCursor.transform.position = cursorTransforms[cursorSelection].transform.position;
        Debug.Log("profile cursor moved to " +  cursorSelection + "th position");

    }
    public void ChangePlayerProfileUI(PlayerData playerData)
    {
        playerProfile.text = "Player Profile: " + PlayerProfiles.instance.playerMaterials[playerData.playerProfileNumber].name;
        profileMoney.text = "Collected Wages: " + playerData.wagesCollected;
        profileWPM.text = "WPM: " + playerData.wpm;
        profileLevels.text = "Level: " + playerData.levelsCompleted;
        if (!playerData.isInitialized)
        {
            profileDelete.text = "";
        }
        else
        {
            profileDelete.text = "Delete :(";
        }
        Debug.Log(playerData.name);
    }
}
