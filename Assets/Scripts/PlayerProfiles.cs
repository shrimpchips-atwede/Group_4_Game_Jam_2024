using System.Collections.Generic;
using System.Diagnostics;
using AASave;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using static PlayerData;
using static RigidbodyPlayerController;


// Save System component on the Save System GameObject.

public class PlayerProfiles : MonoBehaviour
{

    private SaveSystem initSaveSystem;


    public List<Material> playerMaterials;
    


    public bool hasGameStarted = false;

    public static PlayerProfiles instance;

    public int alreadySelected;
    public void Awake()
    {

    }
    public void Start()
    {

        //check if there are any player saves
        //if so, load them into the scene
        //then load the rest of them and make new loads based off a prefab
        //on actual game start, delete all of the player profiles that dont corrospond to a player in the scene
        //for different save files, declare new public save system variables

        //how do i check for subfolders on game start?

        if (instance != null)
        {

            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);

    }

    public void ChangePlayerProfile(PlayerData playerData, int playerProfile, int leftOrRight)
    {
        if( playerData.playerProfileNumber + leftOrRight == alreadySelected)
        {
            leftOrRight = leftOrRight*2;

        }
        if(playerData.playerProfileNumber + leftOrRight > 7)
        {
            playerData.playerProfileNumber = 0;

        }
        else if (playerData.playerProfileNumber + leftOrRight < 7)
        {
            playerData.playerProfileNumber = 7;
        }
        else
        {
            playerData.playerProfileNumber++;
        }

    }
    public void SelectPlayerProfile(PlayerData playerData, int playerProfile)
    {

    }


    public void EraseProfile(PlayerData playerData)
    {
        
    }

}
