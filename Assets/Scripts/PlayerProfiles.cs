using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using static PlayerData;
using static RigidbodyPlayerController;

public class PlayerProfiles : MonoBehaviour
{
    //this will be updated with achievements and level progression for each player
    //does this need to actually be in the scene or can it somehow be accessed from project folder?
    //only save data for two players, but apply that information to the switch statement for the player color

    //do i need have 6 copies of player variables here? or list...

    public List<int> savedPlayerProfiles;//somehow save playerdata externally orz
    public List<int> activePlayerProfiles;

    public List<Material> playerMaterials;
    



    public GameObject player1;
    public GameObject player2;

    //public Material playerMat;
    //public int playerProfile;
    //public int levelsCompleted = 0;
    //public int hat;
    public List<int> LevelsCompleted;

    public bool hasGameStarted = false;



    public static PlayerProfiles instance;

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

        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");//this is super dumb
        //{
        //    for(int i = 0; i < players.Length; i++)
        //    {
        //        if(GetComponent<RigidbodyPlayerController>().playerNumber == 1)
        //        {
        //         player1 = players[i];
        //        }
        //        else if (GetComponent<RigidbodyPlayerController>().playerNumber == 2)
        //        {
        //            player2 = players[i];
        //        }


        //    }


        //}
    }








    public void PlayerColorProfiles(PlayerColor type, PlayerData playerData)
    {
        switch(type)
        {
            case PlayerColor.Red:
                //playerdata.material = red
                //playerdata.achievements = player profiles achievements
                //playerdata.levelscompleted = levels completed
                if(!hasGameStarted)
                {
                    playerData.playerLevelsCompleted = LevelsCompleted[1];
                    playerData.skinnedMeshRenderer.material = playerMaterials[1];
                    //

                }
                else
                {
                    LevelsCompleted[1] = playerData.playerLevelsCompleted;
                }

                break;

            case PlayerColor.Blue:

                break;
            case PlayerColor.Orange:

                break;

            case PlayerColor.Green:

                break;
            case PlayerColor.Yellow:

                break;

            case PlayerColor.Indigo:

                break;


        }
    }


    public void ChangePlayerProfile(int player,bool leftOrRight)
    {
        //using
    }


    public void EraseProfile(int player)
    {

    }
    //strings would have cap of 48 types inc upper/lower. plus its prob innefficient?
    //how else would i do this
    //8 player profiles. save materials, cosmetics(list of total cosmetics, list of cosmetics player achieved)
    // ,save data(linear, int goes up per level completed), achievements(same as cosmetics).
    //kk only worrying about materials for now, will prob ask anthony about player profs later...
}
