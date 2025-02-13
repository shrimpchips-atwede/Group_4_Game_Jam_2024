using System.Collections.Generic;
using AASave;
using UnityEditor.Overlays;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject saveSystemGO;
    public SaveSystem saveSystem;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    //public Material playerMat;

    public int playerNumber = 0;
    public int playerProfileNumber = 0;

    public int levelsCompleted;
    public int wordsCompleted;
    public int wagesCollected;
    public float wpm;
    public List<bool> hatsCollected;
    public List<bool> achievementsCompleted;


    public bool deleteData = false;


    //boolean array for a possible settings menu...
    //orrr, if its better for performance, use bool array for whether or not you have an achievement/hat
    //like always storing list of 50 bools, OR store up to 50 strings in a list... ok so bool list is probably more efficient...




    public void Start()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        if(player.Length > 1 ) {playerNumber = 1; playerProfileNumber = playerNumber; }


        skinnedMeshRenderer.material = PlayerProfiles.instance.playerMaterials[playerNumber];

        Instantiate(saveSystemGO);
        saveSystem = saveSystemGO.GetComponent<SaveSystem>();
        saveSystem.subFolder = true;
        saveSystem.subFolderName = "PlayerData_" + playerNumber.ToString();

    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))//just for playtesting/getting players unstuck
        {
            SavePlayerData();
            Debug.Log("levels completed:" + levelsCompleted + ",wordsCompleted " + wordsCompleted + ",wagesCollected: " + wagesCollected + ",wpm: " + wpm);
        }
        if (Input.GetKeyDown(KeyCode.K))//just for playtesting/getting players unstuck
        {
            LoadPlayerData();
            Debug.Log("levels completed:" + levelsCompleted + ",wordsCompleted " + wordsCompleted + ",wagesCollected: " + wagesCollected + ",wpm: " + wpm);
        }
        if (Input.GetKeyDown(KeyCode.J))//just for playtesting/getting players unstuck
        {
            saveSystem.subFolderName = "PlayerData_" + playerProfileNumber.ToString();
            Debug.Log(saveSystem.subFolderName);
        }
    }

    //public void ChangePlayerProfile(bool RightKey, PlayerData playerData)//this logic is probably dumb... would want to just use ints but doesnt work with logic elsewhere i dont think...
    //{
    //    if(RightKey)
    //    {
    //        if (playerProfileNumber+1 == PlayerProfiles.instance.alreadySelected)
    //        {
    //            playerProfileNumber = PlayerProfiles.instance.alreadySelected+1;
    //            Debug.Log(playerProfileNumber-1 + "is already selected. moving you to" + playerProfileNumber);

    //        }
    //        if (playerProfileNumber+1 > 7)
    //        {
    //            playerProfileNumber = 0;

    //        }
    //        else
    //        {
    //            playerProfileNumber = playerProfileNumber+1;
    //            Debug.Log("value change withing range");
    //        }

    //    }
    //    if(!RightKey)
    //    {
    //        if (playerProfileNumber-1 == PlayerProfiles.instance.alreadySelected)
    //        {
    //            playerProfileNumber = PlayerProfiles.instance.alreadySelected-1;
    //            Debug.Log(playerProfileNumber+1 + "is already selected. moving you to" + playerProfileNumber);

    //        }
    //        if (playerProfileNumber-1 < 0)
    //        {
    //            playerProfileNumber = 7;
    //        }
    //        else
    //        {
    //            playerProfileNumber = playerProfileNumber-1;
    //            Debug.Log("value change within range");
    //        }
    //    }
    //    skinnedMeshRenderer.material = PlayerProfiles.instance.playerMaterials[playerProfileNumber];
    //    saveSystem.subFolderName = "PlayerData_" + playerProfileNumber.ToString();
    //    LoadPlayerData();
    //}

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
        saveSystem.Save("PlayerData_" + playerProfileNumber.ToString() + "_levelsCompleted", levelsCompleted);
        saveSystem.Save("PlayerData_" + playerProfileNumber.ToString() + "_wordsCompleted", wordsCompleted);
        saveSystem.Save("PlayerData_" + playerProfileNumber.ToString() + "_wagesCollected", wagesCollected);
        saveSystem.Save("PlayerData_" + playerProfileNumber.ToString() + "_WPM", wpm);
        //hatsCollected[] = saveSystem.LoadArray("PlayerData_" + playerProfileNumber.ToString() + "_hat").AsBoolArray();//lists to arrays? or smth else
        //achievementsCompleted= saveSystem.LoadArray("PlayerData_" + playerProfileNumber.ToString() + "_achievement").AsBoolArray();
    }
}

