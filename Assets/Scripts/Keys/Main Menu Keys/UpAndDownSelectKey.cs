using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UpAndDownSelectKey : Key
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isUpKey;
    public int charSelectPlayer;//set this to 1 or 2 depending on which player it is being used for
    public GameObject player;
    public PlayerData playerData;
    //public Hats hats;
    public int selection;
    public PlayerProfileUI playerProfileUI;
    //public int cursorSelection = 0;
    



    protected override void KeyPress()
    {
        base.KeyPress();


        if (isUpKey)
        {
            if (playerProfileUI.cursorSelection >= playerProfileUI.cursorTransforms.Count)
            {

                playerProfileUI.cursorSelection = 0;
                return;
            }
            else
            {
                playerProfileUI.cursorSelection = playerProfileUI.cursorSelection+1;
            }

        }
        else
        {
            if (playerProfileUI.cursorSelection == 0)
            {
                playerProfileUI.cursorSelection = playerProfileUI.cursorTransforms.Count-1;
            }
            else
            {
                playerProfileUI.cursorSelection = playerProfileUI.cursorSelection-1;
            }
        }
        playerProfileUI.MoveCursor(playerData);
    }


}
