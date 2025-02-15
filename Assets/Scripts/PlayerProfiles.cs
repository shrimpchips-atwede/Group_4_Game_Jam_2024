using System.Collections.Generic;
using AASave;
using UnityEngine;
using Debug = UnityEngine.Debug;//

// Save System component on the Save System GameObject.

public class PlayerProfiles : MonoBehaviour
{
    public GameObject saveSystemGO;
    public SaveSystem saveSystem;

    public List<Material> playerMaterials;
    
    public bool hasGameStarted = false;

    public static PlayerProfiles instance;

    public int alreadySelected;

    public bool player1Ready = false;
    public bool player2Ready = false;
    //public int cursorSelection = 0;//this is wrong lol



    public void Awake()
    {
        Instantiate(saveSystemGO);
        saveSystem = saveSystemGO.GetComponent<SaveSystem>();
        saveSystem.subFolder = true;
        saveSystem.subFolderName = "PlayerData_7";
        bool exists = saveSystem.DoesDataExists(saveSystem.subFolderName + "_initializedBool");

        Debug.Log("save data exists:" + exists);
        if (exists)
        {
            
            return;
        }

        if(!exists)
        {
            for(int i = 0; i < 8; i++)
            {
                saveSystem.subFolder = true;
                saveSystem.subFolderName = "PlayerData_" + i.ToString();

                BlankProfile(saveSystem);
            }
        }
    }
    public void Start()
    {

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

    public void UpdatePlayerData(bool RightKey, PlayerData playerData, PlayerProfileUI playerProfileUI)//also pass in hat?
    {
        switch (playerProfileUI.cursorSelection)
        {
            case 3:
                ChangePlayerProfile(RightKey, playerData);
                break;

            case 2:
                ChangeHat(RightKey, playerData);
                break;

            case 1:
                PlayerReady(RightKey, playerData);
                break;

            case 0:
                DeleteProfile(RightKey, playerData);
                break;

        }


    }






    public void ChangeHat(bool RightKey, PlayerData playerData)
    {
        //access hat dictionary. using list of bools, make new list of unlocked hats. let player scroll through hats.
    }
    public void ChangePlayerProfile(bool RightKey, PlayerData playerData)//this logic is probably dumb... would want to just use ints but doesnt work with logic elsewhere i dont think...
    {
        if (RightKey)
        {
            if (playerData.playerProfileNumber + 1 == PlayerProfiles.instance.alreadySelected)
            {
                playerData.playerProfileNumber = PlayerProfiles.instance.alreadySelected + 1;
                Debug.Log(playerData.playerProfileNumber - 1 + "is already selected. moving you to" + playerData.playerProfileNumber);

            }
            if (playerData.playerProfileNumber + 1 > 7)
            {
                playerData.playerProfileNumber = 0;

            }
            else
            {
                playerData.playerProfileNumber = playerData.playerProfileNumber + 1;
                Debug.Log("value change withing range");
            }

        }
        if (!RightKey)
        {
            if (playerData.playerProfileNumber - 1 == PlayerProfiles.instance.alreadySelected)
            {
                playerData.playerProfileNumber = PlayerProfiles.instance.alreadySelected - 1;
                Debug.Log(playerData.playerProfileNumber + 1 + "is already selected. moving you to" + playerData.playerProfileNumber);

            }
            if (playerData.playerProfileNumber - 1 < 0)
            {
                playerData.playerProfileNumber = 7;
            }
            else
            {
                playerData.playerProfileNumber = playerData.playerProfileNumber - 1;
                Debug.Log("value change within range");
            }
        }

        playerData.saveSystem.subFolderName = "PlayerData_" + playerData.playerProfileNumber.ToString();
        playerData.LoadPlayerData();
        playerData.skinnedMeshRenderer.material = PlayerProfiles.instance.playerMaterials[playerData.playerProfileNumber];
    }

    public void PlayerReady(bool RightKey, PlayerData playerData)
    {
        PlayerProfiles.instance.alreadySelected = playerData.playerProfileNumber;
        if (RightKey)
        {
            if(playerData.playerNumber == 0)
            {
                player1Ready = true;
            }
            else
            {
                player2Ready = true;
            }
            PlayerProfiles.instance.alreadySelected = playerData.playerProfileNumber;
        }
        else
        {
            if (playerData.playerNumber == 0)
            {
                player1Ready = false;
            }
            else
            {
                player2Ready = false;
            }
            PlayerProfiles.instance.alreadySelected = 100;//idk lol
        }
    }
    public void DeleteProfile(bool RightKey, PlayerData playerData)//02/13/25 need to test logic...
    {
        if (RightKey)
        {
            if(!playerData.deleteData)
            {
                playerData.deleteData = true;
            }
            else
            {
                BlankProfile(playerData.saveSystem);
            }
        }
        else
        {
            if (!playerData.deleteData)
            {
                return;
            }
            else
            {
                playerData.deleteData = false;
            }
        }

    }
    public void BlankProfile(SaveSystem saveSystem)
    {
        bool initializedBool = false;
        saveSystem.Save(saveSystem.subFolderName + "_initializedBool", initializedBool);

        int playerLevelsCompleted = 0;
        saveSystem.Save(saveSystem.subFolderName + "_levelsCompleted", playerLevelsCompleted);

        int playerWordsCompleted = 0;
        saveSystem.Save(saveSystem.subFolderName + "_wordsCompleted", playerWordsCompleted);

        int playerWagesCollected = 0;
        saveSystem.Save(saveSystem.subFolderName + "_wagesCollected", playerWagesCollected);

        float WPM = 0f;
        saveSystem.Save(saveSystem.subFolderName + "_WPM", WPM);

        bool[] playerHatsCollected = { false, false, false };
        saveSystem.Save(saveSystem.subFolderName + "_hat", playerHatsCollected);

        bool[] playerAchievementsCompleted = { false, false, false };
        saveSystem.Save(saveSystem.subFolderName + "_achievement", playerAchievementsCompleted);
    }

}
