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

    //public 

    protected override void KeyPress()
    {
        base.KeyPress();


        if (isUpKey)
        {

        }
        else
        {

        }
    }


}
