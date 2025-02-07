using System.Collections.Generic;
using AASave;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject saveSystemGO;
    public SaveSystem saveSystem;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Material playerMat;

    public int playerNumber;
    public int playerProfileNumber;

    public int levelsCompleted ;
    public int wordsCompleted;
    public int wagesCollected;
    public float wpm;
    public List<bool> hatsCollected;
    public List<bool> achievementsCompleted;


    //boolean array for a possible settings menu...
    //orrr, if its better for performance, use bool array for whether or not you have an achievement/hat
    //like always storing list of 50 bools, OR store up to 50 strings in a list... ok so bool list is probably more efficient...




    public void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        {
            if (players.Length == 1)
            {
                playerNumber = 0;
            }
            else
            {
                playerNumber = 1;
            }
        }
        //is this a dumb way to do this?
        //should i do->bool array to see if any folders exist
        //if they do, load them into char select manager
        //if not, populate ui elements with blank profile info
        //only on confirm player do you apply the info to the player.
        //overthinking this?
        
        skinnedMeshRenderer.material = PlayerProfiles.instance.playerMaterials[playerNumber];

        playerProfileNumber = playerNumber;
        Instantiate(saveSystemGO);
        saveSystem = saveSystemGO.GetComponent<SaveSystem>();
        saveSystem.subFolder = true;
        saveSystem.subFolderName = "PlayerData_" + playerNumber.ToString();


    }




    public void ChangePlayerProfile(bool RightKey)//this logic is probably dumb... would want to just use ints but doesnt work with logic elsewhere i dont think...
    {
        if(RightKey)
        {
            if (playerProfileNumber+1 == PlayerProfiles.instance.alreadySelected)
            {
                playerProfileNumber = PlayerProfiles.instance.alreadySelected+1;

            }
            if (playerProfileNumber+1 > 7)
            {
                playerProfileNumber = 0;

            }
            else
            {
                playerProfileNumber = playerProfileNumber+1;
            }

        }
        if(!RightKey)
        {
            if (playerProfileNumber-1 == PlayerProfiles.instance.alreadySelected)
            {
                playerProfileNumber = PlayerProfiles.instance.alreadySelected-1;

            }
            if (playerProfileNumber-1 < 0)
            {
                playerProfileNumber = 7;
            }
            else
            {
                playerProfileNumber = playerProfileNumber-1;
            }
        }
        skinnedMeshRenderer.material = PlayerProfiles.instance.playerMaterials[playerProfileNumber];
        saveSystem.subFolderName = "PlayerData_" + playerProfileNumber.ToString();
        LoadPlayerData();
    }
    public void LoadPlayerData()
    {

        levelsCompleted = saveSystem.Load("PlayerData_" + playerProfileNumber.ToString() + "_levelsCompleted").AsInt();
        wordsCompleted = saveSystem.Load("PlayerData_" + playerProfileNumber.ToString() + "_wordsCompleted").AsInt();
        wagesCollected = saveSystem.Load("PlayerData_" + playerProfileNumber.ToString() + "_wagesCollected").AsInt();
        wpm = saveSystem.Load("PlayerData_" + playerProfileNumber.ToString() + "_WPM").AsFloat();
        //hatsCollected[] = saveSystem.LoadArray("PlayerData_" + playerProfileNumber.ToString() + "_hat").AsBoolArray();//lists to arrays? or smth else
        //achievementsCompleted= saveSystem.LoadArray("PlayerData_" + playerProfileNumber.ToString() + "_achievement").AsBoolArray();
    }
    public void SavePlayerData()
    {
        //levelsCompleted = 0;
        //wordsCompleted;
        //wagesCollected = 0;
        //hatsCollected;
        //achievementsCompleted;
    }
}

