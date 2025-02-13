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

    //public 

    protected override void KeyPress()
    {
        base.KeyPress();


        if (isUpKey)
        {
            if (PlayerProfiles.instance.cursorSelection == 0 || PlayerProfiles.instance.cursorSelection == 4)
            {
                return;
            }
            else
            {
                PlayerProfiles.instance.cursorSelection++;
            }
        }
        else
        {
            if (PlayerProfiles.instance.cursorSelection == 4 || PlayerProfiles.instance.cursorSelection == 0)
            {
                return;
            }
            else
            {
                PlayerProfiles.instance.cursorSelection--;
            }
        }

    }


}
