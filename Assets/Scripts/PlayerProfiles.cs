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

    


    public void Awake()
    {
        Instantiate(saveSystemGO);
        saveSystem = saveSystemGO.GetComponent<SaveSystem>();
        bool exists = saveSystem.DoesDataExists("PlayerData_7_initializedBool");
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
                bool initialized = true;
                saveSystem.Save(saveSystem.subFolderName + "_initializedBool", initialized);

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

                //playerLevelsCompleted = 
                //playerLevelsCompleted = ;
                //playerhat;
                //collectedWages;
                //achievement;

                //totalWordsTyped;





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

    //public void ChangePlayerProfile(PlayerData playerData, int playerProfile, int leftOrRight)
    //{
    //    if( playerData.playerProfileNumber + leftOrRight == alreadySelected)
    //    {
    //        leftOrRight = leftOrRight*2;

    //    }
    //    if(playerData.playerProfileNumber + leftOrRight > 7)
    //    {
    //        playerData.playerProfileNumber = 0;

    //    }
    //    else if (playerData.playerProfileNumber + leftOrRight < 7)
    //    {
    //        playerData.playerProfileNumber = 7;
    //    }
    //    else
    //    {
    //        playerData.playerProfileNumber++;
    //    }

    //}
    public void SelectPlayerProfile(PlayerData playerData, int playerProfile)
    {

    }


    public void EraseProfile(PlayerData playerData)
    {
        
    }

}
