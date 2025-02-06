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

    public int playerLevelsCompleted = 0;
    public List<string> playerhat;
    public int collectedWages;
    public List<string> achievement;
    public string playerName;
    public int totalWordsTyped;

    //boolean array for a possible settings menu...
    //orrr, if its better for performance, use bool array for whether or not you have an achievement/hat
    //like always storing list of 50 bools, OR store up to 50 strings in a list... ok so bool list is probably more efficient...




    public void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        {
            if (players.Length == 0)
            {
                playerNumber = 0;
            }
            else
            {
                playerNumber = 1;
            }
        }


        skinnedMeshRenderer.material = PlayerProfiles.instance.playerMaterials[playerNumber];
        playerProfileNumber = playerNumber;
        saveSystem = new SaveSystem();
        saveSystem.subFolder = true;
        saveSystem.subFolderName = playerNumber.ToString();
        Debug.Log(saveSystem.subFolderName);
        
    }

    public void ChangePlayer()
    {
        skinnedMeshRenderer.material = PlayerProfiles.instance.playerMaterials[playerNumber];

        //playerLevelsCompleted = ;
        //playerhat;
        //collectedWages;
        //achievement;
        //playerName;
        //totalWordsTyped;
    }

    public void ChangePlayerProfile(bool leftOrRight)
    {
        //change player enum. run enum. thats it? 
    }


}
