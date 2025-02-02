using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public int currentPlayerMaterial;

    public int playerNumber;
    public int playerProfileNumber;

    public SkinnedMeshRenderer playerSkinnedMeshRenderer;
    public Material playerMat;

    public int playerLevelsCompleted = 0;
    public int playerhat;
    public List<string> achievements;
    public enum PlayerColor
    {
        Red,
        Blue,
        Orange,
        Green,
        Yellow,
        Indigo,
    }
    public void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        {
            if (players.Length <= 0)
            {
                playerNumber = 0;
            }
            else
            {
                playerNumber = 1;
            }
        }


        skinnedMeshRenderer.material = PlayerProfiles.instance.playerMaterials[playerNumber];
        currentPlayerMaterial = playerNumber;
    }
    public void UnlockNewLevel(int level)
    {

    }
    public void UnlockAchievement(string achievementName)
    {

    }

    public void ChangePlayerMat(int leftOrRight)
    {
        if (currentPlayerMaterial + leftOrRight < 0)
        {
            currentPlayerMaterial = ScoreManager.instance.materials.Count;
        }
        else if (currentPlayerMaterial + leftOrRight > ScoreManager.instance.materials.Count)
        {
            currentPlayerMaterial = 0;
        }


        skinnedMeshRenderer.material = ScoreManager.instance.materials[currentPlayerMaterial];
    }
    public void ChangePlayerProfile(bool leftOrRight)
    {
        //change player enum. run enum. thats it? 
    }
}
