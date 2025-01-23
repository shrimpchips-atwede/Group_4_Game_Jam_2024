using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerProfiles : MonoBehaviour
{
    //this will be updated with achievements and level progression for each player
    //does this need to actually be in the scene or can it somehow be accessed from project folder?
    public List<int> blankPlayerProfiles;
    public List<int> savedPlayerProfiles;//somehow save playerdata externally orz
    public List<int> activePlayerProfiles;
    public List<Material> playerMaterials;

    public static PlayerProfiles instance;

    public void Start()
    {
        activePlayerProfiles = blankPlayerProfiles;
        savedPlayerProfiles = blankPlayerProfiles;

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













    public void UnlockNewLevel(int level)
    {

    }
    public void UnlockAchievement(string achievementName)
    {

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
